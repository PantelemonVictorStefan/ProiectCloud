using ProiectCloud.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tema4Cloud.Model;

namespace ProiectCloud.Web.Controllers
{
    public class EventsController : ApiController
    {
        // GET: api/Event
        public IEnumerable<EventDTO> GetAll()
        {
            //return new DataAccessAPI().GetAllEvents();
            var events = new DataAccessAPI().GetAllEvents().ToList();
            List<EventDTO> eventDTOs = new List<EventDTO>();
            foreach (var ev in events)
            {
                eventDTOs.Add(new EventDTO(ev));
            }

            return eventDTOs;

        }

        // GET: api/Event/5
        public Event Get(int id)
        {
            return new DataAccessAPI().GetEventById(id);
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
            new DataAccessAPI().DeleteEvent(id);
        }
    }
}