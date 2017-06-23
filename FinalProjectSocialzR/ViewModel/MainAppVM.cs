using FinalProjectSocialzR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.ViewModel
{
    public class MainAppVM
    {
        public IEnumerable<Playlist> Playlists { get; set; }
        public IEnumerable<Blacklist> Blacklists { get; set; }
        public IEnumerable<BlacklistStatic> StaticBlacklist { get; set; }

    }
}