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
            throw new NotImplementedException();
        }

        public BaseModel.OperationMessage EditSolution(BaseModel.SolutionConfiguration solution)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationResult<BaseModel.SolutionConfiguration> GetSolution(Guid solutionId, int version)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationResult<BaseModel.SolutionConfiguration> GetCompleteSolution(Guid solutionId, int version)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationMessage ChangeSolutionStatus(Guid solutionId, bool enable)
        {
            throw new NotImplementedException();
        }

        public BaseModel.OperationResult<int> CreateComponent(BaseModel.Component component)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
