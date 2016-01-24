using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.BaseModel
{
    /// <summary>
    /// 组件类
    /// </summary>
    public class Component:DataClassBase
    {
        /// <summary>
        /// 组件ID
        /// </summary>
        public int ComponentID { set; get; }
        /// <summary>
        /// 组件名称
        /// </summary>
        public string ComponentName { set; get; }
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
    }
}
