using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestorCompound.Models
{
    public class CommentList
    {
        public int CommentId { get; set; }
        [Display(Name = "Comment By")]
        public Guid CommentedBy { get; set; }
        [Display(Name = "Comment")]
        public string CommentContent { get; set; }
        [Display(Name = "Created (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Last Modified (UTC)")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
