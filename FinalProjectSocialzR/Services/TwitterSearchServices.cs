using FinalProjectSocialzR.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
            // Base query 
            var query = ctx.Search.Where(w => w.Type == SearchType.Search && w.Query == searchParam.searchKeyWord);

            // all the if statements
            if (searchParam.Longitude != null || searchParam.Latitude != null || searchParam.Radius != null)
            {
                query = query.Where(w => w.GeoCode == (searchParam.Latitude + "," + searchParam.Longitude + "," + searchParam.Radius + "mi"));
            }
            
            //if (searchParam.Language != null)
            //{
            //    query = query.Where(w => w.SearchLanguage == searchParam.Language);
            //}
            //if (searchParam.ZipCode != null)
            //{
            //    //twitter cant do this
            //}
            //if (searchParam.MustContainPhoto)
            //{
            //    query = query.Where(w => w.Statuses.Any(a => a.ExtendedEntities.MediaEntities.Any(b => b.VideoInfo != null)));
            //}
            //if (searchParam.MustContainVideo)
            //{
            //    query = query.Where(w => w.Statuses.Any(a => a.ExtendedEntities.MediaEntities.Any(b => b.MediaUrl != null)));
            //}
            // to take count && Enumerate it
            var searchResponse = await query.Where(w => w.Count == 100).SingleOrDefaultAsync();
            var tweets = SearchResponseToTweets(searchResponse);

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
                newerTweet.Text = item.Text;
                newerTweet.PostTimeStamp = item.CreatedAt;
                newerTweet.Media = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null)?.ExpandedUrl.ToString();
                newerTweet.MediaImage = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null)?.MediaUrl.ToString();
              
                tweets.Add(newerTweet);
            }
            return tweets; 
        }
    }
}