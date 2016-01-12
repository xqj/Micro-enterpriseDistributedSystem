using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;
using mds.ServiceFactoryService.Core;
using mds.ServiceFactoryService.Model;
using mds.Util;

namespace mds.ServiceFactoryService
{
    public class FactoryServer : IFactoryServer
    {
        private static FactoryServer _intance = new FactoryServer();

        public static IFactoryServer Intance
        {
            get
            {
                return _intance;
            }
        }
        private FactoryServer() {

        }
        public BaseModel.OperationResult<int> InsertService(SolutionServiceFactory info)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r) {
                r.Data = SolutionServiceFactoryDal.Create(info);
                r.ActionResult = (r.Data > 0);
                return r;
            });
        }
        public BaseModel.OperationMessage EditService(SolutionServiceFactory info)
        {
            return FunctionResultProxy.GetResult<OperationMessage>(delegate (OperationMessage r)
            {
                r.ActionResult = (SolutionServiceFactoryDal.Edit(info) > 0);
                return r;
            });
        }

        public BaseModel.OperationResult<List<SolutionServiceFactory>> GetServices(Guid SolutionID,int appUserID)
        {
            return FunctionResultProxy.GetResult<OperationResult<List<SolutionServiceFactory>>>(delegate (OperationResult<List<SolutionServiceFactory>> r)
            {
                var sc = SolutionServiceFactoryDal.Get(SolutionID, appUserID);
                r.Data = sc;
                r.ActionResult = (r.Data != null);
                return r;
            });
        }

        public OperationMessage CreateServices(Guid solutionID, int appUserID)
        {
            return FunctionResultProxy.GetResult<OperationMessage>(delegate (OperationMessage r)
            {
                r.ActionResult = false;
                List<KeyVal<int, string>> compentIDs = SolutionServiceFactoryDal.GetCompentIDList(solutionID);
                if (compentIDs != null)
                {
                    List<SolutionServiceFactory> serviceObjs = new List<SolutionServiceFactory>();
                    compentIDs.ForEach(c => {
                        serviceObjs.Add(new SolutionServiceFactory()
                        {
                            AppUserID = appUserID,
                            SolutionID = solutionID.ToString(),
                             CompentID=c.Key,
                              CompentAssemblyName=c.Val
                        });
                    });
                    r.ActionResult = SolutionServiceFactoryDal.BatchInsert(serviceObjs);
                }
                return r;
            });
           
        }
    }
}