using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text.RegularExpressions;
using zhidaoSignIn.WebApp.Models;
using Newtonsoft.Json;

namespace zhidaoSignIn.WebApp
{
    /// <summary>
    /// Summary description for Corn
    /// </summary>
    public class Corn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            ZhidaoSignIn(context);
        }

        private static void ZhidaoSignIn(HttpContext context)
        {
            string result = string.Empty;

            #region 读取 cookie
            string cookiePath = AppDomain.CurrentDomain.BaseDirectory + "cookie.txt";
            string cookie = File.ReadAllText(cookiePath);
            if (string.IsNullOrEmpty(cookie))
            {
                result = "请检查 cookie.txt";
                context.Response.Write(result);
                return;
            } 
            #endregion

            #region 获取 BDUSS
            string bduss = string.Empty;
            if (cookie.Contains("BDUSS"))
            {
                string pattern = "BDUSS=([a-zA-Z0-9-]+);?";
                Match match = Regex.Match(cookie, pattern);
                if (match.Success)
                {
                    bduss = match.Groups[1].Value;
                }
                else
                {
                    result = "请检查 cookie.txt";
                }
            }
            else
            {
                bduss = cookie;
            }
            #endregion

            #region 发送请求，进行签到
            if (!string.IsNullOrEmpty(bduss))
            {
                int cornPos = context.Request.Url.AbsoluteUri.LastIndexOf("/corn.ashx", StringComparison.OrdinalIgnoreCase);
                // 去掉末尾的 /corn.ashx 再拼接上 /Api/SignIn.ashx?bduss=
                string url = context.Request.Url.AbsoluteUri.Substring(0, cornPos) + "/Api/SignIn.ashx?bduss=" + bduss;

                string jsonStr = HttpAide.HttpGet(url: url);
                dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(jsonStr);
                if (Common.IsPropertyExist(jsonObj, "code") && jsonObj.code.ToString() == "1")
                {
                    result = "签到成功, 签到时间:" + jsonObj.signTime.ToString();
                }
                else
                {
                    result = "签到失败";
                }
            } 
            #endregion
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}