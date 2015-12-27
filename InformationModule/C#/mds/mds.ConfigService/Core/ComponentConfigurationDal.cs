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
    internal partial class ComponentConfigurationDal
    {
        private static IDatabaseService _dalService;
        static ComponentConfigurationDal()
        {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.ComponentConfigurationConnectionName));
            _dalService = obj.CreateIntance();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        internal static int Create(ComponentConfiguration model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ComponentConfiguration(");
            strSql.Append("CreateBy,ModifyTime,ModifyBy,IsDelete,ComponentId,IsDebug,Environment,Content,Enable,Signature,Version,CreateTime");
            strSql.Append(") values (");
            strSql.Append("@CreateBy,@ModifyTime,@ModifyBy,@IsDelete,@ComponentId,@IsDebug,@Environment,@Content,@Enable,@Signature,@Version,@CreateTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@ComponentId", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsDebug", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@Environment", DbType.Int32, 10));
            parameters.Add(new MdsDbParameter("@Content", DbType.String));
            parameters.Add(new MdsDbParameter("@Enable", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@Signature", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@Version", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));


            parameters[0].Value = model.CreateBy;
            parameters[1].Value = model.ModifyTime;
            parameters[2].Value = model.ModifyBy;
            parameters[3].Value = model.IsDelete;
            parameters[4].Value = model.ComponentId;
            parameters[5].Value = model.IsDebug;
            parameters[6].Value = model.Environment;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.Signature;
            parameters[10].Value = model.Version;
            parameters[11].Value = model.CreateTime;
            return _dalService.GetPrimarykey(parameters, strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        internal static int Edit(ComponentConfiguration model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ComponentConfiguration set ");

            strSql.Append(" CreateBy = @CreateBy , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" ModifyBy = @ModifyBy , ");
            strSql.Append(" IsDelete = @IsDelete , ");
            strSql.Append(" ComponentId = @ComponentId , ");
            strSql.Append(" IsDebug = @IsDebug , ");
            strSql.Append(" Environment = @Environment , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" Enable = @Enable , ");
            strSql.Append(" Signature = @Signature , ");
            strSql.Append(" Version = @Version , ");
            strSql.Append(" CreateTime = @CreateTime  ");
            strSql.Append(" where ComponentConfigId=@ComponentConfigId ");

            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@ComponentConfigId", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));

            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));

            parameters.Add(new MdsDbParameter("@ComponentId", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@IsDebug", DbType.Boolean));

            parameters.Add(new MdsDbParameter("@Environment", DbType.Int32, 10));

            parameters.Add(new MdsDbParameter("@Content", DbType.String));

            parameters.Add(new MdsDbParameter("@Enable", DbType.Boolean));

            parameters.Add(new MdsDbParameter("@Signature", DbType.String, 300));

            parameters.Add(new MdsDbParameter("@Version", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));



            parameters[0].Value = model.ComponentConfigId;
            parameters[1].Value = model.CreateBy;
            parameters[2].Value = model.ModifyTime;
            parameters[3].Value = model.ModifyBy;
            parameters[4].Value = model.IsDelete;
            parameters[5].Value = model.ComponentId;
            parameters[6].Value = model.IsDebug;
            parameters[7].Value = model.Environment;
            parameters[8].Value = model.Content;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.Signature;
            parameters[11].Value = model.Version;
            parameters[12].Value = model.CreateTime;
            return _dalService.ExecuteNonQuery(parameters, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ComponentConfiguration Get(int ComponentConfigId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ComponentConfigId, CreateBy, ModifyTime, ModifyBy, IsDelete, ComponentId, IsDebug, Environment, Content, Enable, Signature, Version, CreateTime  ");
            strSql.Append("  from ComponentConfiguration ");
            strSql.Append(" where ComponentConfigId=@ComponentConfigId");
            List<DbParameter> parameters = new List<DbParameter>();

            ComponentConfiguration r = new ComponentConfiguration();
            r = _dalService.GetDataByReader<ComponentConfiguration>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                r = null;
                if (dr.Read())
                {
                    r = new ComponentConfiguration()
                    {
                        ComponentConfigId = int.Parse(dr["ComponentConfigId"].ToString()),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),


                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
                        ComponentId = int.Parse(dr["ComponentId"].ToString()),


                        IsDebug = Boolean.Parse(dr["IsDebug"].ToString()),
                        Environment = int.Parse(dr["Environment"].ToString()),

                        Content = dr["Content"].ToString(),


                        Enable = Boolean.Parse(dr["Enable"].ToString()),
                        Signature = dr["Signature"].ToString(),

                        Version = int.Parse(dr["Version"].ToString()),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),


                    };
                }
                return r;
            });
            return r;

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ComponentConfiguration> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ComponentConfiguration ");
            List<DbParameter> parameters = new List<DbParameter>();
            List<ComponentConfiguration> r;
            return _dalService.GetListByReader<ComponentConfiguration>(parameters, strSql.ToString(), delegate (DbDataReader dr, List<ComponentConfiguration> list) {
                r = new List<ComponentConfiguration>();
                while (dr.Read())
                {
                    r.Add(new ComponentConfiguration()
                    {
                        ComponentConfigId = int.Parse(dr["ComponentConfigId"].ToString()),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),


                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
                        ComponentId = int.Parse(dr["ComponentId"].ToString()),


                        IsDebug = Boolean.Parse(dr["IsDebug"].ToString()),
                        Environment = int.Parse(dr["Environment"].ToString()),

                        Content = dr["Content"].ToString(),


                        Enable = Boolean.Parse(dr["Enable"].ToString()),
                        Signature = dr["Signature"].ToString(),

                        Version = int.Parse(dr["Version"].ToString()),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),


                    });
                }
                if (r.Count == 0) r = null;

            });
        }
    }
}
