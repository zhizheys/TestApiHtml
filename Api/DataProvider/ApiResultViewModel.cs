using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataProvider.Models
{
    public class ApiResultViewModel
    {
        public int ApiResultCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}