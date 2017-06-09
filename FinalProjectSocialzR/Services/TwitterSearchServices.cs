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
using System.Data.SqlClient;

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
                var longLat = await GetLongLatFromMapQuestAsync(searchParam.ZipCode);
                query = query.Where(w => w.GeoCode == (longLat.results.FirstOrDefault().locations.FirstOrDefault().latLng.lat + ","
                                                        + longLat.results.FirstOrDefault().locations.FirstOrDefault().latLng.lng + ","
                                                        + searchParam.Radius + "mi"));
            }
            if (searchParam.Language != null)
            {
                query = query.Where(w => w.SearchLanguage == searchParam.Language);
            }            

            var searchResponse = query.Where(w => w.Count == 100).SingleOrDefaultAsync();
            var tweets = await SearchResponseToTweetsAsync(await searchResponse);

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

        const string connectionString = "Server=tcp:socializrmedia-db.database.windows.net,1433;Initial Catalog=SocializrMediaDB;Persist Security Info=False;User ID=SocializrAdmin;Password=MediaFounders1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static List<string> GetAllBadWords()
        {
            var rv = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Blacklists";
                var cmd = new SqlCommand(sqlQuery, connection);

                connection.Open();
                var sqlrv = cmd.ExecuteReader();
                while (sqlrv.Read())
                {
                    var wordToAdd = sqlrv["Word"].ToString();
                    rv.Add(wordToAdd);
                }

                connection.Close();
            }
            return rv;
        }


        public static async Task<List<Tweet>> SearchResponseToTweetsAsync(LinqToTwitter.Search result)
        {
            var tweets = new List<Tweet>();

            //ApplicationDbContext db2 = new ApplicationDbContext();

            //var listOfBadWords = db2.Blacklists.Select(w => w.Word);

            var listOfBadWords = GetAllBadWords();

            foreach (var item in result.Statuses)
            {
                var newerTweet = new Tweet();
                newerTweet.ImageUrl = item.User.ProfileImageUrl;
                newerTweet.ScreenName = item.User.ScreenNameResponse;
                newerTweet.Text = (Regex.Replace(item.Text, @"http[^\s]+", ""));


                foreach (var item2 in listOfBadWords)
                {
                    if (Regex.IsMatch(newerTweet.Text.ToLower(), item2))
                    {
                        newerTweet.Text = "Contains Bad Words";
                    }
                }
                
                newerTweet.PostTimeStamp = item.CreatedAt;
                newerTweet.Media = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null)?.ExpandedUrl.ToString();
                newerTweet.MediaImage = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null)?.MediaUrl.ToString();

                if (newerTweet.Text == (Regex.Replace(item.Text, @"http[^\s]+", "")).ToString())
                {
                    tweets.Add(newerTweet);
                }
            }
            return tweets; 
        }

        public static async Task<MapQuestAPI> GetLongLatFromMapQuestAsync(string locationKeyWord)
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
      
        public static async Task<string> FilterBadWordsAsync(string input)
        {

            ApplicationDbContext db2 = new ApplicationDbContext();

            var listOfBadWords = await db2.Blacklists.ToListAsync();

            //var listOfBadWords = new List<string> { "shit", "fuck" };
            
            foreach (var item in listOfBadWords)
            {
                if (input.ToLower().Contains(item.ToString())) //Checks BadWords list has the current input tweet text.
                {
                    input = "Contains Bad Words";
                    //remove item from list
                }
                else
                {
                    //continue;
                }
            }


            return input;
        }  
           

    }
}