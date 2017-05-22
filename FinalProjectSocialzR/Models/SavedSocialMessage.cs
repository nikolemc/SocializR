using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.Models
{
    public class SavedSocialMessage
    {
        [Key]
        public int Id { get; set; }

        //determines which social source: twitter, instagram
        public string Source { get; set; }

        [DisplayName("Avatar")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DisplayName("Screen Name")]
        public string ScreenName { get; set; }

        //This is the copied message that may have been edited
        [DisplayName("SocialMessage")]
        public string Text { get; set; }

        [DisplayName("OriginalSocialMessage")]
        public string OriginalText { get; set; }

        public DateTime PostTimeStamp { get; set; }

        // for direct twitter post
        public string PostContentUrl { get; set; }

        public string UserName { get; set; }


        // getting this is a plus 
        public string Location { get; set; }

        public bool IsRetweeted { get; set; }

        public string Language { get; set; }

        public string Media { get; set; }


        // extra data wanted for playlist: time it was added to playlist and by whom
        public DateTime AddedToPlaylistTimeStamp { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }


        public int? PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }


}


