using mds.BaseModel;
using mds.ConfigService.Core;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.ConfigService.Model;

namespace mds.ConfigService
{
    /// <summary>
    /// 单数据
    /// </summary>
    public partial class ConfigServer : IConfigServer
    {

        #region 解决方案
        public BaseModel.OperationResult<int> CreateSolution(BaseModel.SolutionConfiguration solution)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r)
            {
                r.Data = SolutionConfigurationDal.Create(solution);
                r.ActionResult = (r.Data > 0);
                return r;
            });

        }

        public BaseModel.OperationMessage EditSolution(BaseModel.SolutionConfiguration solution)
        {
            return FunctionResultProxy.GetResult<OperationMessage>(delegate (OperationMessage r)
            {
                r.ActionResult = (SolutionConfigurationDal.Edit(solution) > 0);
                return r;
            });
        }

        public BaseModel.OperationResult<BaseModel.SolutionConfiguration> GetSolution(Guid solutionId, int version)
        {
            return FunctionResultProxy.GetResult<OperationResult<SolutionConfiguration>>(delegate (OperationResult<SolutionConfiguration> r)
            {
                var sc = SolutionConfigurationDal.Get(solutionId);
                r.Data = sc;
                r.ActionResult = (r.Data != null);
                return r;
            });
        }
        public BaseModel.OperationMessage ChangeSolutionStatus(Guid solutionId, bool enable)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 组件和组件配置
        public BaseModel.OperationResult<int> CreateComponent(BaseModel.Component component)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r)
            {
                r.Data = ComponentDal.Create(component);
                r.ActionResult = (r.Data > 0);
                return r;
            });
        }

        public BaseModel.OperationMessage EditComponent(BaseModel.Component component)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationMessage DeleteComponent(int componentID)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationResult<int> CreateComponentConfig(BaseModel.ComponentConfiguration componentConfig)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r)
            {
                r.Data = ComponentConfigurationDal.Create(componentConfig);
                r.ActionResult = (r.Data > 0);
                return r;
            });
        }

        public BaseModel.OperationMessage ChangeComponentConfig(BaseModel.ComponentConfiguration componentConfig)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationMessage ChangeComponentConfigStatus(int componentConfigID, bool enable)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationMessage DeleteComponentConfig(int componentConfigID)
        {
            throw new NotImplementedException();
        }
        #endregion

        public BaseModel.OperationResult<int> AddComponentConfigForSolution(Solution_Component_Relation info)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r) {
                r.Data = SolutionComponentRelationDal.Create(info);
                r.ActionResult = (r.Data > 0);
                return r;
            });

        }
    }
}
