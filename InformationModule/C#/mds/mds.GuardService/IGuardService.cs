using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.GuardService
{
   public interface IGuardService
    {
       /// <summary>
       /// 通知程序重新载入配置
       /// </summary>
       /// <returns></returns>
       OperationMessage NoticeAppReLoadConfig(int appID);
       /// <summary>
       /// 通知制定的程序实例重新载入配置
       /// </summary>
       /// <param name="appIntanceID"></param>
       /// <returns></returns>
       OperationMessage NoticeAppIntanceReLoadConfig(int appIntanceID);
    }
}
