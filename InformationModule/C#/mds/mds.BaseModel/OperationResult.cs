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

	public class OperationResult<T>
	{
		public virtual bool ActionResult
		{
			get;
			set;
		}

		public virtual T Data
		{
			get;
			set;
		}

		public virtual OperationMessage Message
		{
			get;
			set;
		}

		public virtual OperationError Error
		{
			get;
			set;
		}

	}
}

