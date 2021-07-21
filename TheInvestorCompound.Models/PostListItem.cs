using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestorCompound.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }
        [Display(Name = "Posted By")]
        public Guid PostedBy { get; set; }
        [Display(Name = "Title")]
        public string PostName { get; set; }
        // Add Later-  not sure of set up yet
        // 
        //public string ShortPost { get; set; }
        [Display(Name = "Created (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
