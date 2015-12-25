using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.GuardClient
{
   public class GuardServiceClient
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
        /// <summary>
        /// 校验程序实例的文件完整性
        /// </summary>
        /// <param name="appIntanceID"></param>
        /// <returns></returns>
        OperationMessage VerifyAppFilse(int appIntanceID);
        /// <summary>
        /// 实例健康（功能完整、存活检查）测试
        /// </summary>
        /// <param name="appIntanceID"></param>
        /// <returns></returns>
        OperationMessage AppIntanceHealthyTest(int appIntanceID);
        /// <summary>
        /// 程序健康（功能完整、存活检查）测试
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        OperationMessage AppHealthyTest(int appID);
    }
}
