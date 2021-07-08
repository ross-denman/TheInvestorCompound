using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestorCompound.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [Display(Name = "Posted By")]
        public string PostedBy { get; set; }
        [Required]
        [MaxLength(160, ErrorMessage = "Please use 160 characters or less")]
        [Display(Name = "Title")]
        public string PostName { get; set; }
        public string PostCoverImage { get; set; }
        [Required]
        public string PostContent { get; set; }
        [Required]
        [Display(Name = "Created (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Last Modified (UTC)")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
