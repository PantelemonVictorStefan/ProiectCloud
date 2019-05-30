using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectCloud.Web.Models
{
    public class CommentViewModel
    {
        [Required]
        [Display(Name = "EventId")]
        public int EventId { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

        public string Author { get; set; }
    }
}