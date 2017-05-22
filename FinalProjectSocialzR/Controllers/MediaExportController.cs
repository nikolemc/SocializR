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
        public ActionResult Index()
        {
            //XDocument doc = new XDocument(new XElement("body",
            //                              new XElement("Message",
            //                              new XElement("Content", "This is an email message"))));

            ApplicationDbContext db = new ApplicationDbContext();

            var mediaToExport = db.SavedSocialMessages.ToList();

            Response.ContentType = "text/xml";
            //Response.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", doc));

            return View(mediaToExport);
        }
    }
}