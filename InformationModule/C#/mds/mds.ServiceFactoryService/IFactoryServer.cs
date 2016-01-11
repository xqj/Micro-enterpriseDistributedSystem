using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.ServiceFactoryService.Model;

namespace mds.ServiceFactoryService
{
    public interface IFactoryServer
    {
        BaseModel.OperationMessage CreateServices(Guid solutionID,int appUserID);
        BaseModel.OperationResult<int> InsertService(SolutionServiceFactory info);
        BaseModel.OperationMessage EditService(SolutionServiceFactory info);
        BaseModel.OperationResult<List<SolutionServiceFactory>> GetServices(Guid solutionID, int appUserID);
    }
}