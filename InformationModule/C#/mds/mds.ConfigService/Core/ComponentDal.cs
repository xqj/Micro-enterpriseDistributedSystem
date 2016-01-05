using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.DataAccess;
using mds.ConfigService.Config;
using System.Data.Common;
using mds.DataAccess.Model;
using System.Data;

namespace mds.ConfigService.Core
{
    internal partial class ComponentDal
    {
        private static IDatabaseService _dalService;
        static ComponentDal()
        {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.ComponentConnectionName));
            _dalService = obj.CreateIntance();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        internal static int Create(Component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Component(");
            strSql.Append("ComponentName,CreateTime,CreateBy,ModifyTime,ModifyBy,IsDelete,ComponentID");
            strSql.Append(") values (");
            strSql.Append("@ComponentName,@CreateTime,@CreateBy,@ModifyTime,@ModifyBy,@IsDelete,@ComponentID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@ComponentName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@ComponentID", DbType.Int32, 11));

            parameters[0].Value = model.ComponentName;
            parameters[1].Value =DateTime.Now;
            parameters[2].Value = model.CreateBy;
            parameters[3].Value = DateTime.Now;
            parameters[4].Value =0;
            parameters[5].Value = false;
            parameters[6].Value = model.ComponentID;
            return _dalService.GetPrimarykey(parameters, strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        internal static int Edit(Component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Component set ");

            strSql.Append(" ComponentName = @ComponentName , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" CreateBy = @CreateBy , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" ModifyBy = @ModifyBy , ");
            strSql.Append(" IsDelete = @IsDelete  ");
            strSql.Append(" where ComponentID=@ComponentID ");

            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@ComponentID", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@ComponentName", DbType.String, 300));

            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));

            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));

            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));



            parameters[0].Value = model.ComponentID;
            parameters[1].Value = model.ComponentName;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.CreateBy;
            parameters[4].Value = model.ModifyTime;
            parameters[5].Value = model.ModifyBy;
            parameters[6].Value = model.IsDelete;
            return _dalService.ExecuteNonQuery(parameters, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Component Get(int ComponentID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ComponentID, ComponentName, CreateTime, CreateBy, ModifyTime, ModifyBy, IsDelete  ");
            strSql.Append("  from Component ");
            strSql.Append(" where ComponentID=@ComponentID");
            List<DbParameter> parameters = new List<DbParameter>();

            Component r = new Component();
            r = _dalService.GetDataByReader<Component>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                r = null;
                if (dr.Read())
                {
                    r = new Component()
                    {
                        ComponentID = int.Parse(dr["ComponentID"].ToString()),

                        ComponentName = dr["ComponentName"].ToString(),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),


                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),

                    };
                }
                return r;
            });
            return r;

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Component> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Component ");
            List<DbParameter> parameters = new List<DbParameter>();
            
            return _dalService.GetListByReader<Component>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                List<Component> r = new List<Component>();
                while (dr.Read())
                {
                    r.Add(new Component()
                    {
                        ComponentID = int.Parse(dr["ComponentID"].ToString()),

                        ComponentName = dr["ComponentName"].ToString(),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),


                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),

                    });
                }
                if (r.Count == 0) r = null;
                return r;
            });
        }
    }
}
