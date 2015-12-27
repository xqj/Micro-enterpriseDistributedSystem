using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService.Config
{
   internal class DefineTable
    {
        public readonly static int ComponentID = 1001;
        public readonly static string SolutionConfigurationConnectionName = "SolutionConfiguration";
        internal static readonly object ComponentConfigurationConnectionName;
        internal static object ComponentConnectionName = "Component";
    }
}
