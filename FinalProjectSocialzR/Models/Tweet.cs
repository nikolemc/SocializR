﻿using System;
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

        // for direct twitter post
        public string PostContentUrl { get; set; }

        public string UserName { get; set; }


        // getting this is a plus 
        public string Location { get; set; }
        
        public int IsRetweeted { get; set; }

        public string Language { get; set; }

        public string Media { get; set; }

        public string MediaImage { get; set; }

        public ulong StatusId { get; set; }
    }
}

