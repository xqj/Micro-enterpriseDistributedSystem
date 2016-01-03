using mds.BaseModel;
using mds.ConfigService.Core;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService
{
    public class ConfigServer : IConfigServer
    {
       
        public BaseModel.OperationResult<int> CreateSolution(BaseModel.SolutionConfiguration solution)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate(OperationResult<int> r) {
                r.Data = SolutionConfigurationDal.Create(solution);
                r.ActionResult = (r.Data > 0);
                return r;
            });
           
        }

        public BaseModel.OperationMessage EditSolution(BaseModel.SolutionConfiguration solution)
        {
            return FunctionResultProxy.GetResult<OperationMessage>(delegate(OperationMessage r)
            {
                r.ActionResult = (SolutionConfigurationDal.Edit(solution)>0);
                return r;
            });
        }

        public BaseModel.OperationResult<BaseModel.SolutionConfiguration> GetSolution(Guid solutionId, int version)
        {
            return FunctionResultProxy.GetResult<OperationResult<SolutionConfiguration>>(delegate(OperationResult<SolutionConfiguration> r)
            {
                var sc = SolutionConfigurationDal.Get(solutionId);
                r.Data = sc;
                r.ActionResult=(r.Data!=null);
                return r;
            });
        }

        public BaseModel.OperationResult<BaseModel.SolutionConfiguration> GetCompleteSolution(Guid solutionId, int version)
        {
            return FunctionResultProxy.GetResult<OperationResult<SolutionConfiguration>>(delegate(OperationResult<SolutionConfiguration> r)
            {
                var sc = SolutionConfigurationDal.Get(solutionId);
                if (sc != null)
                {
                    sc.Components = ComponentConfigurationDal.GetList(solutionId, version);
                    r.Data = sc;
                }
                r.ActionResult = (r.Data != null);
                return r;
            });
        }

        public BaseModel.OperationMessage ChangeSolutionStatus(Guid solutionId, bool enable)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationResult<int> CreateComponent(BaseModel.Component component)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r) {
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
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r) {
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
    }
}
