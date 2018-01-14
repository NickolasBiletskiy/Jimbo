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
                User newUser = new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Ololo",
                    LastName = "hjosdf",
                    Login = "sdfjoasg",
                    Password = "sdofsdj"
                };
                db.User.Add(newUser);
                db.SaveChanges();

                var user = db.User.FirstOrDefault();
                return db.User.ToList();
            }
        }
    }
}
