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
            return PartialView("_TwitterSearchResultsPartial", await FinalProjectSocialzR.Services.TwitterSearchServices.GetTweetsAsync(searchParam));
        }

    }
}