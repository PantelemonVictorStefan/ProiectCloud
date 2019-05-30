using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema4Cloud.Model;

namespace ProiectCloud.Web.Entities
{
    public class EventDTO
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public int NumberOfParticipants { get; set; }

        public int Budget { get; set; }

        public int GatheredMoney { get; set; }

        public System.DateTime DateOfEvent { get; set; }

        public string Description { get; set; }

        public Location Location { get; set; }

        public List<Comment> Comments { get; set; }

        public EventDTO()
        {

        }

        public EventDTO(Event ev)
        {
            Id = ev.Id;
            Title = ev.Title;
            Category = ev.Category;
            NumberOfParticipants = ev.NumberOfParticipants;
            Budget = ev.Budget;
            GatheredMoney = ev.GatheredMoney;
            DateOfEvent = ev.DateOfEvent;
            Description = ev.Description;
            //Location = new Location(ev.Location);
            Location = ev.Location;

            Comments = new List<Comment>();

        }

    }
}