using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.DataAccess.Config
{
    /// <summary>
    /// DataAccess组件配置项目类
    /// </summary>
   public class DataAccessConfiguration
    {
        public string ConnectionName { set; get; }
       /// <summary>
       /// 数据库类型
       /// </summary>
       public EnumDatabaseType DatabaseType { set; get; }
       /// <summary>
       /// 数据库连接字符串
       /// </summary>
       public string DatabaseConnection { set; get; }
       /// <summary>
       /// 是否分库
       /// </summary>
       public bool Multiple { set; get; } 
   }
}
