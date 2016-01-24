using mds.BaseModel;
using mds.ConfigService.Core;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService
{

    public partial class ConfigServer
    {
        public BaseModel.OperationResult<BaseModel.SolutionConfiguration> GetCompleteSolution(Guid solutionId)
        {
            return FunctionResultProxy.GetResult<OperationResult<SolutionConfiguration>>(delegate (OperationResult<SolutionConfiguration> r)
            {
                var sc = SolutionConfigurationDal.Get(solutionId);
                if (sc != null)
                {
                    sc.Components = ComponentConfigurationDal.GetList(solutionId);
                    r.Data = sc;
                }
                r.ActionResult = (r.Data != null);
                return r;
            });
        }
    }
}
