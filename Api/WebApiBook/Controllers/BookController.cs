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
using System.Web.Http;

namespace WebApiBook.Controllers
{
    public class BookController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetAllBook()
        {
            List<Book> BookList = new List<Book>();

            using (var db = new TestDBContext())
            {
                BookList = db.Book.OrderBy(p => p.Id).ToList();
            }

            ApiResultViewModel result = new ApiResultViewModel();
            result.ApiResultCode = (int)ApiResultEnum.Success;
            result.Message = "";
            result.Data = BookList;

            string jsonStr = JsonConvert.SerializeObject(result);

            HttpResponseMessage resultJson = new HttpResponseMessage { Content = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"), "application/json") };
            return resultJson;

        }


    }

}
