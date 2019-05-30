using ProiectCloud.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Tema4Cloud.Model;

namespace ProiectCloud.Web.Business
{
    public class EventManager
    {
        public EventManager()
        {

        }

        public IEnumerable<EventDTO> GetEvents()
        {
            IEnumerable<EventDTO> events = null;
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["BaseURL"];
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("Events");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EventDTO>>();
                    readTask.Wait();

                    events = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    return null;
                }



                return events;
            }

        }

        public Event GetEventById(int id)
        {
            Event ev = null;
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["BaseURL"];
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("Events/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Event>();
                    readTask.Wait();

                    ev = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    return null;
                }
                return ev;
            }
        }

        public bool AddEvent(Event ev)
        {

            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["BaseURL"];
                client.BaseAddress = new Uri(url);
                //HTTP POST
                var responseTask = client.PostAsXmlAsync("Events/", ev);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    var x = result;
                    return false;
                }
            }
        }

        public bool AddComment(Comment comment)
        {
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["BaseURL"];
                client.BaseAddress = new Uri(url);
                //HTTP POST
                var responseTask = client.PostAsXmlAsync("Events/"+comment.EventId+"/Comments", comment);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    var x = result;
                    return false;
                }
            }
        }

    }
}