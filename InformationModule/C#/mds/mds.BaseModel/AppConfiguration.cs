﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
namespace mds.BaseModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    /// <summary>
    /// 程序终节点配置
    /// 对应exe、website对象
    /// 配置加载对象方式和路径的承载对象
    /// 此对象存储在程序对象本地
    /// 不做远程数据配置
    /// </summary>
	public class AppConfiguration
	{
        public int AppID { set; get; }
		/// <summary>
		/// 是否文件方式加载配置，不是则以内存方式加载
		/// </summary>
		public virtual bool IsFileLoad
		{
			get;
			set;
		}

		/// <summary>
		/// 配置模式是否远程化
		/// </summary>
		public virtual bool IsRemote
		{
			get;
			set;
		}

		public virtual Guid SolutionId
		{
			get;
			set;
		}
        /// <summary>
        /// 解决方案版本
        /// </summary>
		public virtual int Version
		{
			get;
			set;
		}
        //远程配置服务地址
        public virtual string RemoteConfigServer { set; get; }
        /// <summary>
        /// 本地模式下配置文件存储路径
        /// </summary>
        public virtual string LocalConfigFilePath { set; get; }

	}
}
