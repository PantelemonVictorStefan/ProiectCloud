using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tema4Cloud.Model;

namespace Tema4Cloud.WebApi.Controllers
{
    public class AccountsController : ApiController
    {
        // GET: api/Accounts
        public IEnumerable<Account> GetAll()
        {
            return new DataAccessAPI().GetAllAccounts();
        }

        // GET: api/Accounts/5
        public Account Get(int id)
        {
            return new DataAccessAPI().GetAccountById(id);
        }

        // POST: api/Accounts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Accounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Accounts/5
        public void Delete(int id)
        {
            new DataAccessAPI().DeleteAccount(id);
        }
    }
}
