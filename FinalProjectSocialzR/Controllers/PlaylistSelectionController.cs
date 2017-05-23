﻿using FinalProjectSocialzR.Models;
using FinalProjectSocialzR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectSocialzR.Controllers
{
    public class PlaylistSelectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PlaylistChoice
        public ActionResult GetPlaylist( int id)
        {
            var rv = db.Playlists.Select(s => new { Playlist = s, Message = s.SavedSocialMessage }).First(f => f.Playlist.Id == id); //take this and put in seperate controller return a partial that is the html.
            var vm = new PlaylistWithSocialMessagesVM {
                Messages = rv.Message,
                PlaylistName = rv.Playlist.PlaylistName,
                Id = id
            };
            return PartialView("_PlaylistSearchResultsPartial", vm);
        }
    }
}