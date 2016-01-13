using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using mds.BaseModel;
using mds.DataAccess;
using mds.DataAccess.Model;
using mds.ServiceFactoryService.Config;
using mds.ServiceFactoryService.Model;

namespace mds.ServiceFactoryService.Core
{
    internal partial class SolutionServiceFactoryDal
    {
        private static IDatabaseService _dalService;
        static SolutionServiceFactoryDal()
        {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.SolutionServiceFactoryConnectionName));
            _dalService = obj.CreateIntance();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        internal static int Create(SolutionServiceFactory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SolutionServiceFactory(");
            strSql.Append("CreateTime,ModifyBy,ModifyTime,IsActive,IsDelete,AppUserID,SolutionID,CompentID,CompentAssemblyName,CompentAssemblyFileName,CompentServiceName,InterfaceName,CreateBy");
            strSql.Append(") values (");
            strSql.Append("@CreateTime,@ModifyBy,@ModifyTime,@IsActive,@IsDelete,@AppUserID,@SolutionID,@CompentID,@CompentAssemblyName,@CompentAssemblyFileName,@CompentServiceName,@InterfaceName,@CreateBy");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@IsActive", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@AppUserID", DbType.Int32, 10));
            parameters.Add(new MdsDbParameter("@SolutionID", DbType.String, 64));
            parameters.Add(new MdsDbParameter("@CompentID", DbType.Int32, 10));
            parameters.Add(new MdsDbParameter("@CompentAssemblyName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CompentAssemblyFileName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CompentServiceName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@InterfaceName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));


            parameters[0].Value = model.CreateTime;
            parameters[1].Value = model.ModifyBy;
            parameters[2].Value = model.ModifyTime;
            parameters[3].Value = model.IsActive;
            parameters[4].Value = model.IsDelete;
            parameters[5].Value = model.AppUserID;
            parameters[6].Value = model.SolutionID;
            parameters[7].Value = model.CompentID;
            parameters[8].Value = model.CompentAssemblyName;
            parameters[9].Value = model.CompentAssemblyFileName;
            parameters[10].Value = model.CompentServiceName;
            parameters[11].Value = model.InterfaceName;
            parameters[12].Value = model.CreateBy;
            return _dalService.GetPrimarykey(parameters, strSql.ToString());
        }

        internal static bool BatchInsert(List<SolutionServiceFactory> serviceObjs)
        {
            var count = 0;
            serviceObjs.ForEach(s => {
                if (Create(s) > 0)
                    count++;
            });
            return (count == serviceObjs.Count);
        }






        /// <summary>
        /// 更新一条数据
        /// </summary>
        internal static int Edit(SolutionServiceFactory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SolutionServiceFactory set ");

            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" ModifyBy = @ModifyBy , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" IsActive = @IsActive , ");
            strSql.Append(" IsDelete = @IsDelete , ");
            strSql.Append(" AppUserID = @AppUserID , ");
            strSql.Append(" SolutionID = @SolutionID , ");
            strSql.Append(" CompentID = @CompentID , ");
            strSql.Append(" CompentAssemblyName = @CompentAssemblyName , ");
            strSql.Append(" CompentAssemblyFileName = @CompentAssemblyFileName , ");
            strSql.Append(" CompentServiceName = @CompentServiceName , ");
            strSql.Append(" InterfaceName = @InterfaceName , ");
            strSql.Append(" CreateBy = @CreateBy  ");
            strSql.Append(" where ID=@ID ");

            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MdsDbParameter("@ID", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@IsActive", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));
            parameters.Add(new MdsDbParameter("@AppUserID", DbType.Int32, 10));
            parameters.Add(new MdsDbParameter("@SolutionID", DbType.String, 64));
            parameters.Add(new MdsDbParameter("@CompentID", DbType.Int32, 10));
            parameters.Add(new MdsDbParameter("@CompentAssemblyName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CompentAssemblyFileName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CompentServiceName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@InterfaceName", DbType.String, 300));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));

            parameters[0].Value = model.ID;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.ModifyBy;
            parameters[3].Value = model.ModifyTime;
            parameters[4].Value = model.IsActive;
            parameters[5].Value = model.IsDelete;
            parameters[6].Value = model.AppUserID;
            parameters[7].Value = model.SolutionID;
            parameters[8].Value = model.CompentID;
            parameters[9].Value = model.CompentAssemblyName;
            parameters[10].Value = model.CompentAssemblyFileName;
            parameters[11].Value = model.CompentServiceName;
            parameters[12].Value = model.InterfaceName;
            parameters[13].Value = model.CreateBy;
            return _dalService.ExecuteNonQuery(parameters, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        internal static SolutionServiceFactory Get(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CreateTime, ModifyBy, ModifyTime, IsActive, IsDelete, AppUserID, SolutionID, CompentID, CompentAssemblyName, CompentAssemblyFileName, CompentServiceName, InterfaceName, CreateBy  ");
            strSql.Append("  from SolutionServiceFactory ");
            strSql.Append(" where ID=@ID");
            List<DbParameter> parameters = new List<DbParameter>();

            SolutionServiceFactory r = new SolutionServiceFactory();
            r = _dalService.GetDataByReader<SolutionServiceFactory>(parameters, strSql.ToString(), delegate (DbDataReader dr)
            {
                r = null;
                if (dr.Read())
                {
                    r = new SolutionServiceFactory()
                    {
                        ID = int.Parse(dr["ID"].ToString()),

                        CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),

                        ModifyBy = int.Parse(dr["ModifyBy"].ToString()),

                        ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString()),


                        IsActive = Boolean.Parse(dr["IsActive"].ToString()),

                        IsDelete = Boolean.Parse(dr["IsDelete"].ToString()),
                        AppUserID = int.Parse(dr["AppUserID"].ToString()),

                        SolutionID = dr["SolutionID"].ToString(),

                        CompentID = int.Parse(dr["CompentID"].ToString()),

                        CompentAssemblyName = dr["CompentAssemblyName"].ToString(),

                        CompentAssemblyFileName = dr["CompentAssemblyFileName"].ToString(),

                        CompentServiceName = dr["CompentServiceName"].ToString(),

                        InterfaceName = dr["InterfaceName"].ToString(),

                        CreateBy = int.Parse(dr["CreateBy"].ToString()),


                    };
                }
                return r;
            });
            return r;

        }       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        internal static List<SolutionServiceFactory> Get(Guid solutionID, int appUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SolutionServiceFactory ");
            List<DbParameter> parameters = new List<DbParameter>();
            return _dalService.GetListByReader<SolutionServiceFactory>(parameters, strSql.ToString(), delegate (DbDataReader dr)
            {
                List<SolutionServiceFactory> r = new List<SolutionServiceFactory>();
                while (dr.Read())
                {
                    r.Add(new SolutionServiceFactory()
                    {
                        AppUserID = int.Parse(dr["AppUserID"].ToString()),
                        SolutionID = dr["SolutionID"].ToString(),
                        CompentID = int.Parse(dr["CompentID"].ToString()),
                        CompentAssemblyName = dr["CompentAssemblyName"].ToString(),
                        CompentAssemblyFileName = dr["CompentAssemblyFileName"].ToString(),
                        CompentServiceName = dr["CompentServiceName"].ToString(),
                        InterfaceName = dr["InterfaceName"].ToString()
                    });
                }
                if (r.Count == 0) r = null;
                return r;
            });
        }
        internal static List<KeyVal<int,string>> GetCompentIDList(Guid solutionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT c.ComponentID,c.CompentAssemblyName FROM ComponentConfiguration AS cc INNER JOIN Solution_Component_Relation AS sct ON sct.ComponentConfigId = cc.ComponentConfigId INNER JOIN Component AS c ON cc.ComponentId = c.ComponentID WHERE sct.IsDelete = 0 AND sct.IsActive = 1 and sct.SolutionId=@SolutionId;");
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MdsDbParameter("@SolutionId",DbType.Guid));
            parameters[0].Value = solutionID;
            return _dalService.GetListByReader<KeyVal<int, string>>(parameters, strSql.ToString(), delegate (DbDataReader dr)
            {
                var r = new List<KeyVal<int, string>>();
                while (dr.Read())
                {
                    r.Add(new KeyVal<int, string>() {
                         Key=dr.GetInt32(0),
                         Val=dr["CompentAssemblyName"].ToString()
                    });
                }
                if (r.Count == 0) r = null;
                return r;
            });
        }
    }
}
