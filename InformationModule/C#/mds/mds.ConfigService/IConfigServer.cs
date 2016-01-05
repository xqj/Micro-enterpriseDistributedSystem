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
        OperationResult<int> CreateSolution(SolutionConfiguration solution);
        /// <summary>
        /// 更改解决方案基础信息
        /// </summary>
        /// <param name="newSolution"></param>
        /// <returns></returns>
        OperationMessage EditSolution(SolutionConfiguration solution);
        /// <summary>
        /// 获取解决方案配置,无组件对象
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        OperationResult<SolutionConfiguration> GetSolution(Guid solutionId, int version);
        /// <summary>
        ///  获取解决方案配置,包括组件对象
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        OperationResult<SolutionConfiguration> GetCompleteSolution(Guid solutionId);
        /// <summary>
        /// 改变解决方案的启用状态
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        OperationMessage ChangeSolutionStatus(Guid solutionId, bool enable);       
        //---------------------------------------------
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        OperationResult<int> CreateComponent(Component component);
        /// <summary>
        /// 编辑组件信息
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        OperationMessage EditComponent(Component component);
        /// <summary>
        /// 删除组件
        /// </summary>
        /// <param name="componentID"></param>
        /// <returns></returns>
        OperationMessage DeleteComponent(int componentID);
        //---------------------------------------------
        /// <summary>
        /// 创建组件配置
        /// </summary>
        /// <param name="newComponent"></param>
        /// <returns></returns>
        OperationResult<int> CreateComponentConfig(ComponentConfiguration componentConfig);
        /// <summary>
        /// 改变组件配置并生成新的版本
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        OperationMessage ChangeComponentConfig(ComponentConfiguration componentConfig);
        /// <summary>
        /// 改变组件配置的启用状态
        /// </summary>
        /// <param name="componentId"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        OperationMessage ChangeComponentConfigStatus(int componentConfigID, bool enable);
        /// <summary>
        /// 删除组件配置
        /// </summary>
        /// <param name="componentConfigID"></param>
        /// <returns></returns>
        OperationMessage DeleteComponentConfig(int componentConfigID);
    }
}
