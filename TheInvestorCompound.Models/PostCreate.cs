using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestorCompound.Models
{
    public class PostCreate
    {
        [Required]
        [MaxLength(160, ErrorMessage = "Please use 160 characters or less")]
        [Display(Name = "Title")]
        public string PostName { get; set; }
        [Display(Name = "Featured Image")]
        public string PostCoverImage { get; set; }
        [Required]
        [MaxLength(12000)]
        [Display(Name ="Content")]
        public string PostContent { get; set; }
    }
}
