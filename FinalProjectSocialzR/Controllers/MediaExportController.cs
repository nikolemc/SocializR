using FinalProjectSocialzR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectSocialzR.Controllers
{
    public class MediaExportController : Controller
    {
        public ActionResult Index(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var mediaToExport = db.SavedSocialMessages.Where(w => w.Playlist.Id == id).ToList();

            Response.ContentType = "text/xml";

            return View(mediaToExport);
        }

        public ActionResult REALIndex(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var mediaToExport = db.SavedSocialMessages.Where(w => w.Playlist.Id == id).ToList();

            Response.ContentType = "text/xml";

            return View(mediaToExport);
        }


    }
}