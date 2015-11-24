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
        /// 创建方案基础信息，不包括组件
        /// </summary>
        /// <param name="newSolution"></param>
        /// <returns></returns>
        OperationResult<int> CreateSolution(SolutionConfiguration newSolution);
        /// <summary>
        /// 更改解决方案基础信息
        /// </summary>
        /// <param name="newSolution"></param>
        /// <returns></returns>
        OperationMessage EditSolution(SolutionConfiguration newSolution);
        /// <summary>
        /// 获取解决方案配置,无组件对象
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        SolutionConfiguration GetSolution(Guid solutionId, int version);
        /// <summary>
        ///  获取解决方案配置,包括组件对象
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        SolutionConfiguration GetComleteSolution(Guid solutionId, int version);

    }
}
