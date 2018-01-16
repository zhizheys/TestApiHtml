﻿using System;
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
using System.Web;
using BaseWeb;

namespace WebApiProcess.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllUser()
        {
            string userId = "aaa@bbb.com";
            string cookieName = "UId";

            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
            }

            cookie.Value = userId;
            cookie.Expires = DateTime.Now.AddMinutes(10);
            cookie.Path = "/";
            HttpContext.Current.Response.Cookies.Add(cookie);

            string bookId = "BookId";
            string cookieBookValue = string.Empty;
            HttpCookie cookieBook = HttpContext.Current.Request.Cookies[bookId];
            if (cookieBook != null)
            {
                cookieBookValue = cookieBook.Value;
            }


            List<User> userList = new List<User>();

            using (var db = new TestDBContext())
            {
                userList = db.User.OrderBy(p => p.UserId).ToList();
            }

            string message = string.Format("cookie name {0},cookie value {1}", bookId, cookieBookValue);

            return CreateHttpResponseMessage((int)ApiResultEnum.Success, message, userList);

        }

    }
}
