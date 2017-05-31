using FinalProjectSocialzR.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using Newtonsoft.Json.Linq;

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

            return PartialView("_TwitterSearchResultsPartial", await FinalProjectSocialzR.Services.TwitterSearchServices.GetTweetsAsync(searchParam));
        }

        //this is the stuff for Instagram

        //private List<Instagram> _instagramItems;

        //public List<Instagram> InstagramItems
        //{
        //    get { return _instagramItems; }
        //    set
        //    {
        //        _instagramItems = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public InstagramViewModel()
        //{
        //    InitDataAsync();
        //}

        //private async Task InitDataAsync()
        //{
        //    var httpClient = new HttpClient();

        //    var json = await httpClient.GetStringAsync(
        //               //"https://www.instagram.com/socialzr/media/"
        //               //this is the URL for SocialzR instragram login
        //               // "https://api.instagram.com/v1/users/469744406/media/recent?client_id=b37af746cd344f5e92a8babb0e003426"
        //               "https://www.instagram.com/oauth/authorize/?client_id=b37af746cd344f5e92a8babb0e003426&redirect_uri=https://localhost:44358/&response_type=token"
        //                );

        //    JObject response = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

        //    var items = response.Value<JArray>("items");

        //    try
        //    {

        //        var instagramItems = new List<Instagram>();

        //        foreach (var item in items)
        //        {
        //            var instagramItem = new Instagram
        //            {
        //                UserName = item.Value<JObject>("user").Value<string>("username"),
        //                FullName = item.Value<JObject>("user").Value<string>("full_name"),
        //                ProfilePicture = item.Value<JObject>("user").Value<string>("profile_picture"),
        //                LowResolutionUrl = item.Value<JObject>("images").Value<JObject>("low_resolution").Value<string>("url"),
        //                StandardResolutionUrl = item.Value<JObject>("images").Value<JObject>("standard_resolution").Value<string>("url"),
        //                ThumbnailUrl = item.Value<JObject>("images").Value<JObject>("thumbnail").Value<string>("url"),
        //                Text = item.Value<JObject>("caption").Value<string>("text"),
        //                CreatedTime = item.Value<JObject>("caption").Value<string>("created_time"),
        //                LikesCount = item.Value<JObject>("likes").Value<int>("count"),
        //                CommentsCount = item.Value<JObject>("comments").Value<int>("count"),
        //            };

        //            instagramItems.Add(instagramItem);
        //        }

        //        InstagramItems = instagramItems;
        //    }
        //    catch (Exception exception)
        //    {

        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }

}
