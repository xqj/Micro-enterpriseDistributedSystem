using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace mds.DataAccess.Model
{
    public class MdsDbParameter : DbParameter
    {
        public MdsDbParameter(string parameterName, DbType dbtype)
        {
            this.ParameterName = parameterName;
            this.DbType = dbtype;
        }
        public MdsDbParameter(string parameterName, DbType dbtype,int size)
        {
            this.ParameterName = parameterName;
            this.DbType = dbtype;
            this.Size = size;
            
        }
        public override DbType DbType
        {
            set; get;
        }

        public override ParameterDirection Direction
        {
            set; get;
        }

        public override bool IsNullable
        {
            set; get;
        }

        public override string ParameterName
        {
            set; get;
        }

        public override int Size
        {
            set; get;
        }

        public override string SourceColumn
        {
            set; get;
        }

        public override bool SourceColumnNullMapping
        {
            set; get;
        }

        public override DataRowVersion SourceVersion
        {
            set; get;
        }

        public override object Value
        {
            set; get;
        }

        public override void ResetDbType()
        {
           
        }
    }
}
