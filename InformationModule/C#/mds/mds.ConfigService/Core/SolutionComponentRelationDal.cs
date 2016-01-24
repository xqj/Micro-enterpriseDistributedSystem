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
using mds.ConfigService.Model;

namespace mds.ConfigService.Core
{
    internal class SolutionComponentRelationDal
    {
        private static IDatabaseService _dalService;
        static SolutionComponentRelationDal()
        {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.SolutionComponentRelationConnectionName));
            _dalService = obj.CreateIntance();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        internal static int Create(Solution_Component_Relation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Solution_Component_Relation(");
            strSql.Append("SolutionId,ComponentConfigId,Version,IsActive,IsDelete,CreateTime,CreateBy");
            strSql.Append(") values (");
            strSql.Append("@SolutionId,@ComponentConfigId,@Version,@IsActive,@IsDelete,@CreateTime,@CreateBy");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@SolutionId", DbType.String, 64));
            parameters.Add(new MdsDbParameter("@ComponentConfigId", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@Version", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsActive", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));

            parameters[0].Value = model.SolutionId;
            parameters[1].Value = model.ComponentConfigId;
            parameters[2].Value = model.Version;
            parameters[3].Value = model.IsActive;
            parameters[4].Value = model.IsDelete;
            parameters[5].Value =DateTime.Now;
            parameters[6].Value = model.CreateBy;
            return _dalService.GetPrimarykey(parameters, strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        internal static int Edit(Solution_Component_Relation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Solution_Component_Relation set ");

            strSql.Append(" SolutionId = @SolutionId , ");
            strSql.Append(" ComponentConfigId = @ComponentConfigId , ");
            strSql.Append(" Version = @Version , ");
            strSql.Append(" IsActive = @IsActive , ");
            strSql.Append(" IsDelete = @IsDelete , ");
            strSql.Append(" CreateTime = @CreateTime  ");
            strSql.Append(" where ID=@ID ");

            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MdsDbParameter("@ID", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@SolutionId", DbType.String, 64));
            parameters.Add(new MdsDbParameter("@ComponentConfigId", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@Version", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsActive", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));

            parameters[0].Value = model.ID;
            parameters[1].Value = model.SolutionId;
            parameters[2].Value = model.ComponentConfigId;
            parameters[3].Value = model.Version;
            parameters[4].Value = model.IsActive;
            parameters[5].Value = model.IsDelete;
            parameters[6].Value = model.CreateTime;
            return _dalService.ExecuteNonQuery(parameters, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        internal static Solution_Component_Relation Get(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, SolutionId, ComponentConfigId, Version, IsActive, IsDelete, CreateTime  ");
            strSql.Append("  from Solution_Component_Relation ");
            strSql.Append(" where ID=@ID");
            List<DbParameter> parameters = new List<DbParameter>();

            Solution_Component_Relation r = new Solution_Component_Relation();
            r = _dalService.GetDataByReader<Solution_Component_Relation>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                r = null;
                if (dr.Read())
                {
                    r = new Solution_Component_Relation()
                    {
                        ID = int.Parse(dr["ID"].ToString()),

                        SolutionId = dr["SolutionId"].ToString(),

                        ComponentConfigId = int.Parse(dr["ComponentConfigId"].ToString()),

                        Version = int.Parse(dr["Version"].ToString()),


                        IsActive = Boolean.Parse(dr["IsActive"].ToString()),

                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
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
        internal static List<Solution_Component_Relation> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Solution_Component_Relation ");
            List<DbParameter> parameters = new List<DbParameter>();
            
            return _dalService.GetListByReader<Solution_Component_Relation>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                List<Solution_Component_Relation> r = new List<Solution_Component_Relation>();
                while (dr.Read())
                {
                    r.Add(new Solution_Component_Relation()
                    {
                        ID = int.Parse(dr["ID"].ToString()),

                        SolutionId = dr["SolutionId"].ToString(),

                        ComponentConfigId = int.Parse(dr["ComponentConfigId"].ToString()),

                        Version = int.Parse(dr["Version"].ToString()),


                        IsActive = Boolean.Parse(dr["IsActive"].ToString()),

                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),


                    });
                }
                if (r.Count == 0) r = null;
                return r;
            });
        }
    }
}