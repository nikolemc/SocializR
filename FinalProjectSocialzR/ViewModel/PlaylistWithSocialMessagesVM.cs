using FinalProjectSocialzR.Models;
using System.Collections.Generic;

namespace FinalProjectSocialzR.ViewModel
{
    public class PlaylistWithSocialMessagesVM
    {
        
        public int Id { get; set; }
        public string SelectedPlayListName { get; set; }

        public IEnumerable<Playlist> AllPlaylist { get; set; }
    
        public IEnumerable<SavedSocialMessage> Messages { get; set; }
    
    }
}