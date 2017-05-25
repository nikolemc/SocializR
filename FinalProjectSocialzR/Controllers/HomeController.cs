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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var name = HttpContext.User.Identity.Name;
                var userId = User.Identity.GetUserId();
                var userName = User.Identity.GetUserName();
            }
            //var vm = new ApplicationDbContext().Tweet.OrderByDescending(o => o.PostedTimeStamp).Include(i => i.message).ToList();
            //return View(vm);
            return View();
        }

        //This can be used for only allowing superUsers and Admin to post to twitter.
        [Authorize(Roles = "superUser, Administrator")]
        public ActionResult AddPost()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
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
    }
}

