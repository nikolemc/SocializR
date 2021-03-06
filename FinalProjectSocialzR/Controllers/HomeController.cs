﻿using FinalProjectSocialzR.Models;
using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Configuration;
using FinalProjectSocialzR.ViewModel;

namespace FinalProjectSocialzR.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var name = HttpContext.User.Identity.Name;
                var userId = User.Identity.GetUserId();
                var userName = User.Identity.GetUserName();
            }

            var compId = db.Users.Find(User.Identity.GetUserId())?.CompanyId;

            var playlist = new ApplicationDbContext().Playlists.Where(w => w.CompanyId == compId).ToList();
            var blacklist = new ApplicationDbContext().Blacklists.Where(w => w.CompanyId == compId).ToList();
            var secondBlacklist = new ApplicationDbContext().blacklistStatics.ToList();

            var vm = new MainAppVM() {Playlists = playlist, Blacklists = blacklist, StaticBlacklist = secondBlacklist };

            return View(vm);
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
            var vm = db.Blacklists.Where(w => w.Id > 300).ToList();

            return View("_blacklistPartial", vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }        
    }
}

