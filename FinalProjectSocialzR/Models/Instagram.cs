using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.Models
{
    public class Instagram
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public string Text { get; set; }

        public string CreatedTime { get; set; }

        public string LowResolutionUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public string StandardResolutionUrl { get; set; }        

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }
    }
}