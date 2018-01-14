using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data.DbContext;
using Data.Entities;

namespace Jimbo.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public List<User> GetUsers()
        {
            using (EntityContext db = new EntityContext())
            {
                var user = db.Users.FirstOrDefault();
                return db.Users.ToList();
            }
        }
    }
}
