using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using Data;
using Data.DbContext;
using Data.Entities;
using Jimbo.Models;

namespace Jimbo.Controllers
{
    public class LoginController : ApiController
    {
        #region dependencies

        private readonly EntityContext _entityContext;
        private Repository<User> _userRepository;
        private int _daysToLogOut;

        #endregion

        #region .cstor

        public LoginController()
        {
            _entityContext = new EntityContext();
            _userRepository = new Repository<User>(_entityContext);
            int.TryParse(WebConfigurationManager.AppSettings["SessionExpireDays"], out _daysToLogOut);
        }

        #endregion

        #region Public Actions

        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginViewModel viewModel)
        {
            try
            {
                var user = _userRepository.GetWhere(u => u.Login == viewModel.Login && u.Password == viewModel.Password);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ResponseMessages.MessageDictionary[ResponseCodes.USER_NOT_REGISTERED]);

                DateTime today = DateTime.UtcNow;

                user.LastLoginTs = today;
                user.SessionExpireDate = today.AddDays(_daysToLogOut);
                user.SessionId = Guid.NewGuid();
                _userRepository.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, user.SessionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString());
            }
        }
        #endregion

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
