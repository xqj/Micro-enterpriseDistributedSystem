using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.DataAccess;
using mds.ConfigService.Config;

namespace mds.ConfigService.Core
{
   internal class SolutionConfigurationDal
    {
        private static IDatabaseService _dalService;
         static SolutionConfigurationDal() {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.SolutionConfigurationConnectionName));
            _dalService = obj.CreateIntance();
        }
        internal static int Create(BaseModel.SolutionConfiguration solution)
        {
            throw new NotImplementedException();
        }

        internal static int Edit(BaseModel.SolutionConfiguration solution)
        {
            throw new NotImplementedException();
        }

        internal static SolutionConfiguration Get(Guid solutionId)
        {
            throw new NotImplementedException();
        }
    }
}
