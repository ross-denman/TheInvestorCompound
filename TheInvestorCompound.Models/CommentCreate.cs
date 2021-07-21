using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestorCompound.Models
{
    public class CommentCreate
    {

        [Required]
        [MaxLength(6000)]
        [Display(Name = "Content")]
        public string CommentContent { get; set; }
    }
}
