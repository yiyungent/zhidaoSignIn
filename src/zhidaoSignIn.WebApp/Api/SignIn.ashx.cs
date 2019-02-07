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
                    context.Response.Write("签到成功");
                }
                else
                {
                    context.Response.Write("签到失败");
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