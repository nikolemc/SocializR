using FinalProjectSocialzR.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FinalProjectSocialzR.Services
{
    public class TwitterSearchServices
    {
        public static async Task<List<Tweet>> GetTweetsAsync(TwitterSearchParam searchParam)
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var query = ctx.Search.Where(w => w.Type == SearchType.Search && w.Query == searchParam.searchKeyWord);

            if (searchParam.Longitude != null && searchParam.Latitude != null && searchParam.Radius != null && searchParam.ZipCode != null)
            {
                query = query.Where(w => w.GeoCode == (searchParam.Latitude + "," + searchParam.Longitude + "," + searchParam.Radius + "mi"));
            }
            if (searchParam.ZipCode != null)
            {
                if (searchParam.Radius == null)
                {
                    searchParam.Radius = "50";
                }
                var longLat = GetLongLatFromMapQuest(searchParam.ZipCode);
                query = query.Where(w => w.GeoCode == (longLat.results.FirstOrDefault().locations.FirstOrDefault().latLng.lat + ","
                                                        + longLat.results.FirstOrDefault().locations.FirstOrDefault().latLng.lng + ","
                                                        + searchParam.Radius + "mi"));
            }
            if (searchParam.Language != null)
            {
                query = query.Where(w => w.SearchLanguage == searchParam.Language);
            }            

            var searchResponse = await query.Where(w => w.Count == 100).SingleOrDefaultAsync();
            var tweets = SearchResponseToTweets(searchResponse);

            if (!searchParam.IncludeRetweet)
            {
                tweets = tweets.Where(w => w.StatusId == 0).ToList();
            }
            if (searchParam.MustContainVideo)
            {
                tweets = tweets.Where(w => w.Media != null).ToList();
            }
            if (searchParam.MustContainPhoto)
            {
                tweets = tweets.Where(w => w.MediaImage != null).ToList();
            }

            return tweets;
        }

        public static List<Tweet> SearchResponseToTweets(LinqToTwitter.Search result)
        {
            var tweets = new List<Tweet>();

            foreach (var item in result.Statuses)
            {
                var newerTweet = new Tweet();
                newerTweet.ImageUrl = item.User.ProfileImageUrl;
                newerTweet.ScreenName = item.User.ScreenNameResponse;
                newerTweet.Text = Regex.Replace(item.Text, @"http[^\s]+", "");
                newerTweet.PostTimeStamp = item.CreatedAt;
                newerTweet.Media = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null)?.ExpandedUrl.ToString();
                newerTweet.MediaImage = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null)?.MediaUrl.ToString();

                newerTweet.StatusId = item.RetweetedStatus.StatusID;

                tweets.Add(newerTweet);
            }
            return tweets; 
        }

        public static MapQuestAPI GetLongLatFromMapQuest(string locationKeyWord)
        {
            var sourceURL = "http://www.mapquestapi.com/geocoding/v1/address?key=vNk6zEQGUM2jOLdMZM98A72SrZIYR5CU&location=" + locationKeyWord;

            var request = WebRequest.Create(sourceURL);

            var response = request.GetResponse();

            var rawResponse = String.Empty;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var theWeather = JsonConvert.DeserializeObject<MapQuestAPI>(rawResponse);
            Console.WriteLine(theWeather.results.FirstOrDefault().locations.FirstOrDefault().latLng.lat);

            return theWeather;
        }

    }
}