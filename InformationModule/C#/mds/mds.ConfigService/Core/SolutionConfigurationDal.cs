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
    internal partial class SolutionConfigurationDal
    {
        private static IDatabaseService _dalService;
        static SolutionConfigurationDal()
        {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.SolutionConfigurationConnectionName));
            _dalService = obj.CreateIntance();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        internal static int Create(SolutionConfiguration model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SolutionConfiguration(");
            strSql.Append("CreateTime,CreateBy,ModifyTime,ModifyBy,IsDelete,SolutionId,SolutionName,Version,IsFile,Content,Enable,Environment,IsRemote");
            strSql.Append(") values (");
            strSql.Append("@CreateTime,@CreateBy,@ModifyTime,@ModifyBy,@IsDelete,@SolutionId,@SolutionName,@Version,@IsFile,@Content,@Enable,@Environment,@IsRemote");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@SolutionId", DbType.Guid, 64));
            parameters.Add(new MdsDbParameter("@SolutionName", DbType.String, 200));
            parameters.Add(new MdsDbParameter("@Version", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsFile", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@Content", DbType.String));
            parameters.Add(new MdsDbParameter("@Enable", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@Environment", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsRemote", DbType.Boolean));


            parameters[0].Value =DateTime.Now;
            parameters[1].Value = model.CreateBy;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = model.ModifyBy;
            parameters[4].Value = false;
            parameters[5].Value = model.SolutionId;
            parameters[6].Value = model.SolutionName;
            parameters[7].Value = model.Version;
            parameters[8].Value = model.IsFile;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.Enable;
            parameters[11].Value = model.Environment;
            parameters[12].Value = model.IsRemote;
            return _dalService.GetPrimarykey(parameters, strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        internal static int Edit(SolutionConfiguration model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SolutionConfiguration set ");

            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" CreateBy = @CreateBy , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" ModifyBy = @ModifyBy , ");
            strSql.Append(" IsDelete = @IsDelete , ");
            strSql.Append(" SolutionId = @SolutionId , ");
            strSql.Append(" SolutionName = @SolutionName , ");
            strSql.Append(" Version = @Version , ");
            strSql.Append(" IsFile = @IsFile , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" Enable = @Enable , ");
            strSql.Append(" Environment = @Environment , ");
            strSql.Append(" IsRemote = @IsRemote  ");
            strSql.Append(" where ID=@ID ");

            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@ID", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));

            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));

            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));

            parameters.Add(new MdsDbParameter("@SolutionId", DbType.String, 64));

            parameters.Add(new MdsDbParameter("@SolutionName", DbType.String, 200));

            parameters.Add(new MdsDbParameter("@Version", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@IsFile", DbType.Boolean));

            parameters.Add(new MdsDbParameter("@Content", DbType.String));

            parameters.Add(new MdsDbParameter("@Enable", DbType.Boolean));

            parameters.Add(new MdsDbParameter("@Environment", DbType.Int32, 11));

            parameters.Add(new MdsDbParameter("@IsRemote", DbType.Boolean));



            parameters[0].Value = model.ID;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.CreateBy;
            parameters[3].Value = model.ModifyTime;
            parameters[4].Value = model.ModifyBy;
            parameters[5].Value = model.IsDelete;
            parameters[6].Value = model.SolutionId;
            parameters[7].Value = model.SolutionName;
            parameters[8].Value = model.Version;
            parameters[9].Value = model.IsFile;
            parameters[10].Value = model.Content;
            parameters[11].Value = model.Enable;
            parameters[12].Value = model.Environment;
            parameters[13].Value = model.IsRemote;
            return _dalService.ExecuteNonQuery(parameters, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        internal static SolutionConfiguration Get(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CreateTime, CreateBy, ModifyTime, ModifyBy, IsDelete, SolutionId, SolutionName, Version, IsFile, Content, Enable, Environment, IsRemote  ");
            strSql.Append("  from SolutionConfiguration ");
            strSql.Append(" where ID=@ID");
            List<DbParameter> parameters = new List<DbParameter>();

            SolutionConfiguration r = new SolutionConfiguration();
            r = _dalService.GetDataByReader<SolutionConfiguration>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                r = null;
                if (dr.Read())
                {
                    r = new SolutionConfiguration()
                    {
                        ID = int.Parse(dr["ID"].ToString()),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),


                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
                        SolutionId = Guid.Parse(dr["SolutionId"].ToString()),

                        SolutionName = dr["SolutionName"].ToString(),

                        Version = int.Parse(dr["Version"].ToString()),


                        IsFile = Boolean.Parse(dr["IsFile"].ToString()),
                        Content = dr["Content"].ToString(),


                        Enable = Boolean.Parse(dr["Enable"].ToString()),
                        Environment = int.Parse(dr["Environment"].ToString()),


                        IsRemote = Boolean.Parse(dr["IsRemote"].ToString()),

                    };
                }
                return r;
            });
            return r;

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        internal static List<SolutionConfiguration> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SolutionConfiguration ");
            List<DbParameter> parameters = new List<DbParameter>();
            List<SolutionConfiguration> r;
            return _dalService.GetListByReader<SolutionConfiguration>(parameters, strSql.ToString(), delegate (DbDataReader dr, List<SolutionConfiguration> list) {
                r = new List<SolutionConfiguration>();
                while (dr.Read())
                {
                    r.Add(new SolutionConfiguration()
                    {
                        ID = int.Parse(dr["ID"].ToString()),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),


                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
                        SolutionId =Guid.Parse(dr["SolutionId"].ToString()),

                        SolutionName = dr["SolutionName"].ToString(),

                        Version = int.Parse(dr["Version"].ToString()),


                        IsFile = Boolean.Parse(dr["IsFile"].ToString()),
                        Content = dr["Content"].ToString(),


                        Enable = Boolean.Parse(dr["Enable"].ToString()),
                        Environment = int.Parse(dr["Environment"].ToString()),


                        IsRemote = Boolean.Parse(dr["IsRemote"].ToString()),

                    });
                }
                if (r.Count == 0) r = null;

            });
        }
    }
}
