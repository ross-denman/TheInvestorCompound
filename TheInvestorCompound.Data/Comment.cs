using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestorCompound.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [Display(Name = "Commented By")]
        public Guid CommentedBy { get; set; }
        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }
        [Required]
        public string CommentContent { get; set; }
        [Required]
        [Display(Name = "Comment Date (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Comment Modified (UTC)")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
