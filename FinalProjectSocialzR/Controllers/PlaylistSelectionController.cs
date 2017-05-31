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
    public class PlaylistSelectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PlaylistChoice
        public ActionResult GetPlaylist(int id)
        {
            var rv = db.Playlists.Select(s => new { Playlist = s, Message = s.SavedSocialMessage, }).First(f => f.Playlist.Id == id);
            var playLists = db.Playlists.ToList();
            var vm = new PlaylistWithSocialMessagesVM
            {
                Messages = rv.Message,
                PlayListName = rv.Playlist.PlaylistName,
                AllPlaylist = playLists,
                Id = id
            };
            return PartialView("_PlaylistSearchResultsPartial", vm);
        }

        [HttpPut]
        public ActionResult EditPlaylist(int id, string newPlaylistName)
        {
            Playlist playlist = db.Playlists.Find(id);
            playlist.PlaylistName = newPlaylistName;
            db.Entry(playlist).State = EntityState.Modified;
            db.SaveChanges();

            var rv = db.Playlists.Select(s => new { Playlist = s, }).First(f => f.Playlist.Id == id);
            var playLists = db.Playlists.ToList();
            var vm = new PlaylistWithSocialMessagesVM
            {
                Id = id,
                PlayListName = rv.Playlist.PlaylistName,
                AllPlaylist = db.Playlists.ToList()

            };

            return PartialView("_PlaylistPartial", vm);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include =
        "Id,PlaylistName,LastModifiedTimeStamp")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var vm = new PlaylistWithSocialMessagesVM { };

            return PartialView("_PlaylistPartial", vm);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            var listToRemove = db.SavedSocialMessages.Where(w => w.PlaylistId == id).ToList();

            foreach (var item in listToRemove)
            {
                db.SavedSocialMessages.Remove(item);
            }


            db.Entry(playlist).State = EntityState.Modified;
            db.Playlists.Remove(playlist);
            db.SaveChanges();

            var vm = new PlaylistWithSocialMessagesVM { };

            return PartialView("_PlaylistPartial", vm);
        }



    }




}

