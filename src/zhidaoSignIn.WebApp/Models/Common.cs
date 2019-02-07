using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json.Linq;

namespace zhidaoSignIn.WebApp.Models
{
    public class Common
    {
        public static bool IsPropertyExist(dynamic data, string propertyname)
        {
            if (data is JObject)
            {
                return ((JObject)data).ContainsKey(propertyname);
            }
            return false;
        }
    }
}