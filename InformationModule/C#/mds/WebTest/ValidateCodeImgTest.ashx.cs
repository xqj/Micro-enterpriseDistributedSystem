using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    /// <summary>
    /// ValidateCodeImgTest 的摘要说明
    /// </summary>
    public class ValidateCodeImgTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ClearContent();
            context.Response.ContentType = "image/jpeg";
            byte[] bytes = ValidateCodeImgae.CreateValidateGraphic("1234");
            context.Response.BinaryWrite(bytes);
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