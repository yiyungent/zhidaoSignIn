using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using zhidaoSignIn.WebApp.Models;

namespace zhidaoSignIn.WebApp.Api
{
    /// <summary>
    /// Summary description for SignIn
    /// </summary>
    public class SignIn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bduss = context.Request.QueryString["bduss"];
            if (!string.IsNullOrEmpty(bduss))
            {
                Zhidao zhidao = new Zhidao();
                if (zhidao.SignIn(bduss))
                {
                    context.Response.Write("{ \"code\": 1, \"message\": \"签到成功\",  \"signTime\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" }");
                }
                else
                {
                    context.Response.Write("{ \"code\": -1, \"message\": \"签到失败\",  \"signTime\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" }");
                }
            }
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