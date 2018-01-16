
namespace WebApiAuthentication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebApiAuthentication.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using BaseWeb;
    using DataProvider;
    using DataProvider.DataBase;

    public class AuthenticationController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Login(UserViewModel user)
        {
            string userId = user.UserId;
            string userPassword = user.UserPassword;
            User findUser;

            try
            {
                using (var db = new TestDBContext())
                {
                    findUser = db.User.Where(p => p.UserName == userId).Where(p => p.UserPassword == userPassword).FirstOrDefault();
                    if (findUser == null)
                    {
                        return CreateHttpResponseMessage((int)ApiResultEnum.NoLogin, null, null);
                    }
                }

                return CreateHttpResponseMessage((int)ApiResultEnum.Success, null, new { UserId = user.UserId });
            }
            catch (Exception ex)
            {
                return CreateHttpResponseMessage((int)ApiResultEnum.Error, ex.ToString(), null);
            }
        }

    }
}
