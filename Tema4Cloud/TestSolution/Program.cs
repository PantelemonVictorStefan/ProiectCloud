using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema4Cloud.Model;

namespace TestSolution
{
    class Program
    {

        public static void AddData()
        {
            var acc = new Account();
            acc.Email = "victorbarosan@gmail.com";
            acc.Password = "parolastudent";
            acc.Username = "VictorSefuTau";
            DataAccessAPI.AddAccount(acc);

            var ev = new Event();
            ev.Budget = 4000;
            ev.Category = "caritate";
            ev.DateOfEvent = DateTime.Now;
            ev.Description = "Testarea adaugarii datelor in baza de date";
            ev.GatheredMoney = 2416;
            ev.Location = "Camera mea";
            ev.NumberOfParticipants = 22;
            ev.Title = "testare";
    

            DataAccessAPI.AddEvent(ev);
        }

        public static void ReadData()
        {
            var events = DataAccessAPI.GetAllEvents();
            var accounts = DataAccessAPI.GetAllAccounts();
            Console.WriteLine("EVENTS:");
            foreach (var ev in events)
            {
                Console.WriteLine("{0}  {1}",ev.Title,ev.Description);
            }
            Console.WriteLine("ACCOUNTS:");
            foreach (var acc in accounts)
            {
                Console.WriteLine("{0}  {1}", acc.Username, acc.Email);
            }

        }

        public static void UpdateData()
        {
            var ev = DataAccessAPI.GetEventById(1);
            ev.Title = "Testare update";
            ev.NumberOfParticipants++;
            DataAccessAPI.UpdateEvent(ev);

            var acc = DataAccessAPI.GetAccountById(1);
            acc.Username = "UpdatedUsername";
            DataAccessAPI.UpdateAccount(acc);
        }

        public static void DeleteData()
        {
            DataAccessAPI.DeleteEvent(1);
            DataAccessAPI.DeleteAccount(1);
        }

        static void Main(string[] args)
        {
            //AddData();
            //ReadData();
            //UpdateData();
            //ReadData();
            //DeleteData();
            ReadData();
        }
    }
}
