using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tema4Cloud.Model;

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

        public Comment GetAsComment()
        {
            var comment = new Comment();
            comment.Author = this.Author;
            comment.Date = DateTime.UtcNow;
            comment.EventId = this.EventId;
            comment.Text = this.Text;

            return comment;
        }
    }
}