using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tema4Cloud.Model;

namespace ProiectCloud.Web.Models
{
    public class EventViewModel
    {

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Budget")]
        public int Budget { get; set; }
        [Required]
        [Display(Name = "DateOfEvent")]
        public System.DateTime DateOfEvent { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }


        public Event GetAsEvent()
        {
            Location loc = new Location();
            loc.Latitude = Latitude;
            loc.Longitude = Longitude;


            Event ev = new Event();
            ev.Budget = Budget;
            ev.Category = Category;
            ev.DateOfEvent = DateOfEvent;
            ev.Description = Description;
            ev.GatheredMoney = 0;
            ev.NumberOfParticipants = 0;
            ev.Title = Title;
            ev.Location = loc;

            return ev;
        }
    }
}