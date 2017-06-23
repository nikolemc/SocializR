using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectSocialzR.Models;

namespace FinalProjectSocialzR.ViewModel
{
    public class BlacklistExtendedVM
    {
        public IEnumerable<Blacklist> Blacklist { get; set; }
        public IEnumerable<BlacklistStatic> BlacklistStatic { get; set; }

    }
}