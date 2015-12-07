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
	/// 组件配置文件基础（必有）配置项目
	/// </summary>
	public class ComponentConfiguration : DataClassBase
	{
		/// <summary>
		/// 是否进行调试
		/// </summary>
		public virtual bool IsDebug
		{
			get;
			set;
		}

		/// <summary>
		/// 运行环境
		/// </summary>
		public virtual int Environment
		{
			get;
			set;
		}

		public virtual int ComponentId
		{
			get;
			set;
		}

		

		public virtual string Content 
		{
			get;
			set;
		}

		public virtual bool Enable
		{
			get;
			set;
		}
        /// <summary>
        /// 为0时就一直取最新的版本， 配置版本号，改变一次配置内容自动递增
        /// </summary>
        public virtual int Version
        {
            get;
            set;
        }
        /// <summary>
        /// 软件签名
        /// </summary>
        public virtual string Signature { set; get; }

    }
}

