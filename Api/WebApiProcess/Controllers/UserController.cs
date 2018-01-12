using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;
using WebApiProcess.Models;
using Newtonsoft.Json;
using System.Text;
using DataProvider;
using DataProvider.DataBase;
using DataProvider.Models;

namespace WebApiProcess.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllUser()
        {
            List<User> userList = new List<User>();

            using(var db = new TestDBContext())
            {
                userList = db.User.OrderBy(p => p.UserId).ToList();
            }

            ApiResultViewModel result = new ApiResultViewModel();
            result.ApiResultCode = (int)ApiResultEnum.Success;
            result.Message = "";
            result.Data = userList;

            string jsonStr = JsonConvert.SerializeObject(result);

            HttpResponseMessage resultJson = new HttpResponseMessage { Content = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"), "application/json") };
            return resultJson;

        }

    }
}
