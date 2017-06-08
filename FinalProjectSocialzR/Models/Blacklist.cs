using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.Models
{
    public class Blacklist
    {
        [Key]
        public int Id { get; set; }
        public string Word { get; set; }
    }
}