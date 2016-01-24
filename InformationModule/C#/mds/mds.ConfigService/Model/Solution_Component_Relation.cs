using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService.Model
{
   public class Solution_Component_Relation
    {
        /// <summary>
        /// auto_increment
        /// </summary>		
        public int ID
        {
            set; get;
        }
        /// <summary>
        /// SolutionId
        /// </summary>		
        public string SolutionId
        {
            set; get;
        }
        /// <summary>
        /// ComponentConfigId
        /// </summary>		
        public int ComponentConfigId
        {
            set; get;
        }
        /// <summary>
        /// Version
        /// </summary>		
        public int Version
        {
            set; get;
        }
        /// <summary>
        /// IsActive
        /// </summary>		
        public bool IsActive
        {
            set; get;
        }
        /// <summary>
        /// IsDelete
        /// </summary>		
        public bool IsDelete
        {
            set; get;
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime
        {
            set; get;
        }
        public int CreateBy { get;  set; }
    }
}
