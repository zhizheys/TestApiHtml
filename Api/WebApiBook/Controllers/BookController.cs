using DataProvider;
using DataProvider.DataBase;
using DataProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using BaseWeb;

namespace WebApiBook.Controllers
{
    public class BookController : BaseApiController
    {

        [HttpGet]
        public HttpResponseMessage GetAllBook()
        {
            string bookId = "book@shenzhen.com";
            string cookieName = "BookId";

            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
            }

            cookie.Value = bookId;
            cookie.Expires = DateTime.Now.AddMinutes(10);
            cookie.Path = "/";
            HttpContext.Current.Response.Cookies.Add(cookie);

            string userId = "UId";
            HttpCookie cookieUser = HttpContext.Current.Request.Cookies[userId];
            string cookieUserValue = string.Empty;

            if (cookieUser != null)
            {
                cookieUserValue = cookieUser.Value;
            }

            List<Book> BookList = new List<Book>();

            using (var db = new TestDBContext())
            {
                BookList = db.Book.OrderBy(p => p.Id).ToList();
            }

            //ApiResultViewModel result = new ApiResultViewModel();
            //result.ApiResultCode = (int)ApiResultEnum.Success;
            //result.Message = string.Format("cookie name {0},cookie value {1}", userId, cookieUserValue);
            //result.Data = BookList;

            //string jsonStr = JsonConvert.SerializeObject(result);

            //HttpResponseMessage resultJson = new HttpResponseMessage { Content = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"), "application/json") };
            //return resultJson;

            return CreateHttpResponseMessage((int)ApiResultEnum.Success, null, BookList);

        }


    }

}
