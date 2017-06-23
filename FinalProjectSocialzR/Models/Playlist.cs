using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProjectSocialzR.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string PlaylistName { get; set; }
        public DateTime LastModifiedTimeStamp { get; set; } = DateTime.Now;

        public ICollection<SavedSocialMessage> SavedSocialMessage { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}