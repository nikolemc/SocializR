using FinalProjectSocialzR.Models;
using FinalProjectSocialzR.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectSocialzR.Controllers
{
    public class SavedSocialMessagesCRUDController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SavedSocialMessagesCRUD
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]        
        public ActionResult Delete(int id, int playListId)
        {
            SavedSocialMessage savedSocialMessage = db.SavedSocialMessages.Find(id);
            db.SavedSocialMessages.Remove(savedSocialMessage);
            db.SaveChanges();

            var rv = db.Playlists.Select(s => new { Playlist = s, Message = s.SavedSocialMessage, }).First(f => f.Playlist.Id == playListId); //take this and put in seperate controller return a partial that is the html.
            var playLists = db.Playlists.ToList();
            var vm = new PlaylistWithSocialMessagesVM
            {
                Messages = rv.Message,
                SelectedPlayListName = rv.Playlist.PlaylistName,
                AllPlaylist = playLists,
                Id = id
            };

            return PartialView("_PlaylistSearchResultsPartial", vm);
        }

        [HttpPut]
        public ActionResult EditMessage(int id, int playListId, string newText)
        {           
            SavedSocialMessage savedSocialMessage = db.SavedSocialMessages.Find(id);
            savedSocialMessage.Text = newText;
            db.Entry(savedSocialMessage).State = EntityState.Modified;
            db.SaveChanges();

            var rv = db.Playlists.Select(s => new { Playlist = s, Message = s.SavedSocialMessage, }).First(f => f.Playlist.Id == playListId); //take this and put in seperate controller return a partial that is the html.
            var playLists = db.Playlists.ToList();
            var vm = new PlaylistWithSocialMessagesVM
            {
                Messages = rv.Message,
                SelectedPlayListName = rv.Playlist.PlaylistName,
                AllPlaylist = playLists,
                Id = id
            };

            return PartialView("_PlaylistSearchResultsPartial", vm);
        }


    }
}