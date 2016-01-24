using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ServiceFactoryService.Model
{
    public class SolutionServiceFactory
    {

        /// <summary>
        /// auto_increment
        /// </summary>		
        public int ID
        {
            set; get;
        }
        /// <summary>
        /// AppUserID
        /// </summary>		
        public int AppUserID
        {
            set; get;
        }
        /// <summary>
        /// SolutionID
        /// </summary>		
        public string SolutionID
        {
            set; get;
        }
        /// <summary>
        /// CompentID
        /// </summary>		
        public int CompentID
        {
            set; get;
        }
        /// <summary>
        /// CompentAssemblyName
        /// </summary>		
        public string CompentAssemblyName
        {
            set; get;
        }
        /// <summary>
        /// CompentAssemblyFileName
        /// </summary>		
        public string CompentAssemblyFileName
        {
            set; get;
        }
        /// <summary>
        /// CompentServiceName
        /// </summary>		
        public string CompentServiceName
        {
            set; get;
        }
        /// <summary>
        /// InterfaceName
        /// </summary>		
        public string InterfaceName
        {
            set; get;
        }
        public string AssemblyVersion
        {
            set;get;
        }
        /// <summary>
        /// CreateBy
        /// </summary>		
        public int CreateBy
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
        /// <summary>
        /// ModifyBy
        /// </summary>		
        public int ModifyBy
        {
            set; get;
        }
        /// <summary>
        /// ModifyTime
        /// </summary>		
        public DateTime ModifyTime
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
    }
}
