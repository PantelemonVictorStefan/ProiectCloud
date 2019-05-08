using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4Cloud.Model
{
    public static class DataAccessAPI
    {

        private static DataAccessModelContainer ctx = new DataAccessModelContainer();

        public static void AddEvent(Event e)
        {
            ctx.Events.Add(e);
            ctx.SaveChanges();
        }

        public static IQueryable<Event> GetAllEvents()
        {
            return ctx.Events.AsQueryable();
        }

        public static Event GetEventById(int id)
        {
           return ctx.Events.Where(q=>q.Id==id ).First();
        }

        public static void UpdateEvent(Event e)
        {
            var oldEvent=ctx.Events.Find(e.Id);
            oldEvent = e;
            ctx.SaveChanges();

        }

        public static void DeleteEvent(int id)
        {
            var itemToDelete = ctx.Events.Find(id);
            ctx.Events.Remove(itemToDelete);
            ctx.SaveChanges();
        }

        public static void AddAccount(Account acc)
        {
            ctx.Accounts.Add(acc);
            ctx.SaveChanges();
        }

        public static IQueryable<Account> GetAllAccounts()
        {
            return ctx.Accounts.AsQueryable();
        }

        public static Account GetAccountById(int id)
        {
            return ctx.Accounts.Where(q => q.Id == id).First();
        }

        public static void UpdateAccount(Account acc)
        {
            var oldAccount = ctx.Accounts.Find(acc.Id);
            oldAccount = acc;
            ctx.SaveChanges();

        }

        public static void DeleteAccount(int id)
        {
            var itemToDelete = ctx.Accounts.Find(id);
            ctx.Accounts.Remove(itemToDelete);
            ctx.SaveChanges();
        }
    }
}
