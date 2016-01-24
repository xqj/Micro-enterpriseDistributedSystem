using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;

namespace JsTest
{
    /// <summary>
    /// WebServiceTest 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
     [System.Web.Script.Services.ScriptService]
    public class WebServiceTest : System.Web.Services.WebService
    {

        [WebMethod]
        public t HelloWorld(string requestId)
        {
            var t1 = new t() { 
             Data="Hello World:" + requestId
            };
            return t1;
        }
    }
 [DataContract]
    public class t
    {
        [DataMember]
        public string Data { set; get; }
    }
}
