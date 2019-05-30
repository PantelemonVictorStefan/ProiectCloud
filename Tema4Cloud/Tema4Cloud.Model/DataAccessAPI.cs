using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4Cloud.Model
{
    public class DataAccessAPI
    {

        private  DataAccessModelContainer ctx = new DataAccessModelContainer();

        public void AddEvent(Event e)
        {
            ctx.Events.Add(e);
            ctx.SaveChanges();
        }

        public IQueryable<Event> GetAllEvents()
        {
            return ctx.Events.AsQueryable();
        }

        public Event GetEventById(int id)
        {
           return ctx.Events.Where(q=>q.Id==id ).First();
        }

        public void UpdateEvent(Event e)
        {
            var oldEvent=ctx.Events.Find(e.Id);

            //oldEvent = e;

            ctx.Entry(oldEvent).CurrentValues.SetValues(e);
            oldEvent.Location = e.Location;
            //oldEvent.
            ctx.SaveChanges();

        }

        public void DeleteEvent(int id)
        {
            var itemToDelete = ctx.Events.Find(id);
            ctx.Events.Remove(itemToDelete);
            ctx.SaveChanges();
        }

        public void AddAccount(Account acc)
        {
            ctx.Accounts.Add(acc);
            ctx.SaveChanges();
        }

        public IQueryable<Account> GetAllAccounts()
        {
            return ctx.Accounts.AsQueryable();
        }

        public Account GetAccountById(int id)
        {
            return ctx.Accounts.Where(q => q.Id == id).First();
        }

        public void UpdateAccount(Account acc)
        {
            var oldAccount = ctx.Accounts.Find(acc.Id);
            ctx.Entry(oldAccount).CurrentValues.SetValues(acc);
            ctx.SaveChanges();

        }

        public void DeleteAccount(int id)
        {
            var itemToDelete = ctx.Accounts.Find(id);
            ctx.Accounts.Remove(itemToDelete);
            ctx.SaveChanges();
        }
    }
}
