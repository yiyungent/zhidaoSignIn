using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace zhidaoSignIn.WebApp.Models
{
    public class Zhidao
    {
        #region 百度知道签到
        /// <summary>
        /// 百度知道签到
        /// </summary>
        /// <param name="bduss"></param>
        /// <returns>是否签到成功</returns>
        public bool SignIn(string bduss)
        {
            string url = "https://zhidao.baidu.com/msubmit/signin?random=0.3507959078709957&";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            Dictionary<string, string> cookies = new Dictionary<string, string>();
            cookies.Add("BDUSS", bduss);
            string postDataStr = "ssid=&cifr=";
            string jsonStr = HttpAide.HttpPost(url: url, postDataStr: postDataStr, cookies: cookies, ua: userAgent);
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(jsonStr);

            bool isSuccess = Common.IsPropertyExist(jsonObj, "errno") && jsonObj.errno.ToString() == "0" && Common.IsPropertyExist(jsonObj, "errmsg") && jsonObj.errmsg == "success" && Common.IsPropertyExist(jsonObj, "submit");
            return isSuccess;
        }
        #endregion
    }
}