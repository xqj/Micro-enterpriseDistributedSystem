using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService
{
    public class ConfigServer : IConfigServer
    {
        public BaseModel.SolutionConfiguration GetSolution(Guid solutionId, int version)
        {
            throw new NotImplementedException();
        }
    }
}
