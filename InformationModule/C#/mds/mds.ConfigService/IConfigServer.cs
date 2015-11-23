using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService
{
    public interface IConfigServer
    {
        /// <summary>
        /// 获取解决方案配置
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        SolutionConfiguration GetSolution(Guid solutionId, int version);

    }
}
