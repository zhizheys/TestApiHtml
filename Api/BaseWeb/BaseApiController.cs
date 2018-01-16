using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DataProvider.Models;
using Newtonsoft.Json;
using DataProvider;

namespace BaseWeb
{
    public class BaseApiController : ApiController
    {
        public static HttpResponseMessage CreateHttpResponseMessage(int apiResultCode, string message, object data)
        {
            ApiResultViewModel result = new ApiResultViewModel();
            result.ApiResultCode = apiResultCode;
            result.Message = message;
            result.Data = data;
            string jsonStr = JsonConvert.SerializeObject(result);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage { Content = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"), "application/json") };

            return httpResponseMessage;
        }
    }
}
