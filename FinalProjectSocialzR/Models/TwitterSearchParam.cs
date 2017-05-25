using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.Models
{
    public class TwitterSearchParam
    {
        public int Id { get; set; }
        public bool MustContainPhoto { get; set; } = false;
        public bool MustContainVideo { get; set; } = false;
        public string searchKeyWord { get; set; }
        public string Language { get; set; }
        public bool IncludeRetweet { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Radius { get; set; }

    }
}  