using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{

    public enum ApiResultEnum
    {
        Success = 2200,
        Error = 2503,
        NoLogin =2500,
        NoPermission=2401,
        NotFound = 2404
    }

}
