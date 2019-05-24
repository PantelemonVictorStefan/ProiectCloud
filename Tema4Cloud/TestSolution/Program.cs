using ProiectCloud.Web;
using ProiectCloud.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Tema4Cloud.Model;

namespace TestSolution
{
    class Program
    {

        public static void AddData()
        {
            
           /* var acc = new Account();
            acc.Email = "victorbarosan@gmail.com";
            acc.Password = "parolastudent";
            acc.Username = "VictorSefuTau";
            new DataAccessAPI().AddAccount(acc);

            var ev = new Event();
            ev.Budget = 4000;
            ev.Category = "caritate";
            ev.DateOfEvent = DateTime.Now;
            ev.Description = "Testarea adaugarii datelor in baza de date";
            ev.GatheredMoney = 2416;
            ev.Location = "Camera mea";
            ev.NumberOfParticipants = 22;
            ev.Title = "testare";


            new DataAccessAPI().AddEvent(ev);*/
        }

        public static void ReadData()
        {
            var events = new DataAccessAPI().GetAllEvents();
            var accounts = new DataAccessAPI().GetAllAccounts();
            Console.WriteLine("EVENTS:");
            foreach (var ev in events)
            {
                Console.WriteLine("event title:{0}\n  Event description:{1}\nEvent participants:{2}\nEvent id:{3}\nLocation-Latitude:{4}\nLocation-Longitude:{5}",ev.Title,ev.Description,ev.NumberOfParticipants,ev.Id,ev.Location.Latitude,ev.Location.Longitude);
            }
            /*Console.WriteLine("ACCOUNTS:");
            foreach (var acc in accounts)
            {
                Console.WriteLine("{0}  {1}", acc.Username, acc.Email);
            }*/

        }

        public static void UpdateData()
        {
            var ev = new DataAccessAPI().GetAllEvents().First();
            ev.Title = "Testare update";
            ev.NumberOfParticipants++;
            new DataAccessAPI().UpdateEvent(ev);

            var acc = new DataAccessAPI().GetAllAccounts().First();
            acc.Username = "UpdatedUsername";
            new DataAccessAPI().UpdateAccount(acc);
        }

        public static void DeleteData()
        {
            var api = new DataAccessAPI();
            var events = api.GetAllEvents().ToArray();
            foreach (var ev in events)
            {
                api.DeleteEvent(ev.Id);
            }
        }

        public static void PopulateDatabase()
        {
            var api = new DataAccessAPI();
            for (int i = 0; i < 100; i++)
            {
                Location location = new Location();
                location.Latitude = i;
                location.Longitude = i;

                Event ev = new Event();
                ev.Budget = 100 * i;
                ev.Category = "De Proba";
                ev.DateOfEvent = DateTime.Now;
                ev.Description = "Event pentru popularea bazei de date";
                ev.GatheredMoney = ev.Budget / 2 * i + 1;
                ev.Location = location;
                ev.NumberOfParticipants = i + 1;
                ev.Title = "Dummy" + i;
                api.AddEvent(ev);
            }
        }
        

        static void Main(string[] args)
        {
            //AddData();
            //ReadData();
            //UpdateData();
            //ReadData();
            DeleteData();
            //PopulateDatabase();
            ReadData();
        }
    }
}
