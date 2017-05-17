using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.Models
{
    public class Tweet
    {
        [DisplayName("Avatar")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DisplayName("Screen Name")]
        public string ScreenName { get; set; }

        [DisplayName("Tweet")]
        public string Text { get; set; }

        public DateTime PostTimeStamp { get; set; }

        // this is for images and videos inside of the post
        public string PostContentUrl { get; set; }

        public string UserName { get; set; }


        // getting this is a plus 
        public string Location { get; set; }
        
        public bool IsRetweeted { get; set; }

        public string Language { get; set; }

         

    }
}

