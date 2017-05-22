﻿using FinalProjectSocialzR.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectSocialzR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [ActionName("CustomSearch")]
        public async Task<ActionResult> CustomSearchAsync(string searchTerm)
        {

            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var searchResponse =
                 await
                 (from search in ctx.Search
                  where search.Type == SearchType.Search &&
                        search.Query == ("\"" + searchTerm + "\"")
                  select search)
                 .SingleOrDefaultAsync();

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
                        Media = item.ExtendedEntities.MediaEntities.First().ExpandedUrl.ToString()
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
                    };
                    tweets.Add(tweetToAdd);
                }
                                
            }

            return PartialView("_TwitterSearchResultsPartial", tweets);
        }

        [ActionName("CustomSearchZip")]
        public async Task<ActionResult> CustomSearchZipAsync(string searchTermZip = "trump", string lati = "27.782254", string longi = "-82.667619", string radi = "1")
        {
            
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var searchResponse =
                 await
                 (from search in ctx.Search
                  where search.Type == SearchType.Search &&
                        search.GeoCode == (lati + "," + longi + "," + radi + "mi") &&
                        search.Query == ("\"" + searchTermZip + "\"") &&
                        search.Count == 100
                  select search)
                 .SingleOrDefaultAsync();

            var tweets = new List<Tweet>();

            foreach (var item in searchResponse.Statuses)
            {
                var tweetToAdd = new Tweet
                {
                    ImageUrl = item.User.ProfileImageUrl,
                    ScreenName = item.User.ScreenNameResponse,
                    Text = item.Text,
                    PostTimeStamp = item.CreatedAt,
                    UserName = item.User.Name,
                    PostContentUrl = item.OEmbedUrl,

                };


                tweets.Add(tweetToAdd);
            }

            return View(tweets);
        }

        [ActionName("GetXML")]
        public ActionResult GetXML(string placeHolder)
        {
                      


            return View();
        }


    }
}

