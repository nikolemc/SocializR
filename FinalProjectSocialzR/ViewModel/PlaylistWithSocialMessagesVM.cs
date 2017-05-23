using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FinalProjectSocialzR.Models;

namespace FinalProjectSocialzR.ViewModel
{
    public class PlaylistWithSocialMessagesVM
    {
        
        public int Id { get; set; }

        public string PlaylistName { get; set; }
        public IEnumerable<SavedSocialMessage> Messages { get; set; }
        //determines which social source: twitter, instagram
        //public string Source { get; set; }

        //[DisplayName("Avatar")]
        //[DataType(DataType.ImageUrl)]
        //public string ImageUrl { get; set; }

        //[DisplayName("Screen Name")]
        //public string ScreenName { get; set; }

        ////This is the copied message that may have been edited
        //[DisplayName("SocialMessage")]
        //public string Text { get; set; }
        
        //public DateTime PostTimeStamp { get; set; }

        //// for direct twitter post
        //public string PostContentUrl { get; set; }

        //public string UserName { get; set; }


        


    }
}