using FinalProjectSocialzR.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FinalProjectSocialzR.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("TwitterAdvancedSearch")]
        public async Task<ActionResult> TwitterAdvancedSearchAsync(TwitterSearchParam searchParam)
        {

            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);
            /// var searchResponse = new LinqToTwitter.Search();

            //if (searchParam.Latitude != null || searchParam.Latitude == null || searchParam.Radius == null)
            //{
            //    searchResponse =
            //      await
            //      (from search in ctx.Search
            //       where search.Type == SearchType.Search &&
            //             search.Query == ("\"" + searchParam.searchKeyWord + "\"")
            //       select search)
            //      .SingleOrDefaultAsync();
            //}

            //if (searchParam.Latitude != null || searchParam.Latitude != null || searchParam.Radius != null)
            //{
            //    searchResponse =
            //      await
            //      (from search in ctx.Search
            //       where search.Type == SearchType.Search &&
            //             search.GeoCode == (searchParam.Latitude + "," + searchParam.Longitude + "," + searchParam.Radius + "mi") &&
            //             search.Query == ("\"" + searchParam.searchKeyWord + "\"") &&
            //             search.Count == 100
            //       select search)
            //      .SingleOrDefaultAsync();
            //}

            // Base query 
            var query = ctx.Search.Where(w => w.Type == SearchType.Search && w.Query == searchParam.searchKeyWord);//.Select(s => s).SingleOrDefaultAsync();

            // all the if statements
            if (searchParam.Latitude != null || searchParam.Latitude != null || searchParam.Radius != null)
            {
                query = query.Where(w => w.GeoCode == (searchParam.Latitude + "," + searchParam.Longitude + "," + searchParam.Radius + "mi"));
            }

            // to take count && Enumerate it
            var searchResponse = await query.Where(w => w.Count == 100).SingleOrDefaultAsync();

            var tweets = new List<Tweet>();

            foreach (var item in searchResponse.Statuses)
            {
                if (item.ExtendedEntities.MediaEntities.Count != 0)
                {
                    var tweetToAdd = new Tweet
                    {
                        ImageUrl = item.User.ProfileImageUrl,
                        ScreenName = item.User.ScreenNameResponse,
                        Text = item.Text,
                        PostTimeStamp = item.CreatedAt,
                        Media = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null).ExpandedUrl.ToString(),
                        MediaImage = item.ExtendedEntities.MediaEntities.FirstOrDefault(f => f.ExpandedUrl != null).MediaUrl.ToString()
                    };
                    tweets.Add(tweetToAdd);
                }
                else
                {
                    var tweetToAdd = new Tweet
                    {
                        ImageUrl = item.User.ProfileImageUrl,
                        ScreenName = item.User.ScreenNameResponse,
                        Text = item.Text,
                        PostTimeStamp = item.CreatedAt
                    };
                    tweets.Add(tweetToAdd);
                }
            }

            return PartialView("_TwitterSearchResultsPartial", tweets);
        }

    }
}