using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.DataAccess;
using System.Data.Common;
using mds.DataAccess.Model;
using System.Data;
using mds.AppUserService.Config;
using mds.AppUserService.Model;

namespace mds.AppUserService.Core
{
    internal class AppUserDal
    {
        private static IDatabaseService _dalService;
        static AppUserDal()
        {
            var obj = new DataAccessService(ConfigHelper.GetDalConfig(DefineTable.AppUserConnectionName));
            _dalService = obj.CreateIntance();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        internal static int Create(AppUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AppUser(");
            strSql.Append("AppUserLogin,AppUserName,AppUserPwd,CreateTime,CreateBy,ModifyTime,ModifyBy,IsDelete");
            strSql.Append(") values (");
            strSql.Append("@AppUserLogin,@AppUserName,@AppUserPwd,@CreateTime,@CreateBy,@ModifyTime,@ModifyBy,@IsDelete");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new MdsDbParameter("@AppUserLogin", DbType.String, 30));
            parameters.Add(new MdsDbParameter("@AppUserName", DbType.String, 20));
            parameters.Add(new MdsDbParameter("@AppUserPwd", DbType.String, 200));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));


            parameters[0].Value = model.AppUserLogin;
            parameters[1].Value = model.AppUserName;
            parameters[2].Value = model.AppUserPwd;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.CreateBy;
            parameters[5].Value = model.ModifyTime;
            parameters[6].Value = model.ModifyBy;
            parameters[7].Value = model.IsDelete;
            return _dalService.GetPrimarykey(parameters, strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        internal static int Edit(AppUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AppUser set ");

            strSql.Append(" AppUserLogin = @AppUserLogin , ");
            strSql.Append(" AppUserName = @AppUserName , ");
            strSql.Append(" AppUserPwd = @AppUserPwd , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" CreateBy = @CreateBy , ");
            strSql.Append(" ModifyTime = @ModifyTime , ");
            strSql.Append(" ModifyBy = @ModifyBy , ");
            strSql.Append(" IsDelete = @IsDelete  ");
            strSql.Append(" where AppUserID=@AppUserID ");

            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MdsDbParameter("@AppUserID", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@AppUserLogin", DbType.String, 30));
            parameters.Add(new MdsDbParameter("@AppUserName", DbType.String, 20));
            parameters.Add(new MdsDbParameter("@AppUserPwd", DbType.String, 200));
            parameters.Add(new MdsDbParameter("@CreateTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@CreateBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@ModifyTime", DbType.DateTime));
            parameters.Add(new MdsDbParameter("@ModifyBy", DbType.Int32, 11));
            parameters.Add(new MdsDbParameter("@IsDelete", DbType.Boolean));

            parameters[0].Value = model.AppUserID;
            parameters[1].Value = model.AppUserLogin;
            parameters[2].Value = model.AppUserName;
            parameters[3].Value = model.AppUserPwd;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.CreateBy;
            parameters[6].Value = model.ModifyTime;
            parameters[7].Value = model.ModifyBy;
            parameters[8].Value = model.IsDelete;
            return _dalService.ExecuteNonQuery(parameters, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        internal static AppUser Get(int AppUserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AppUserID, AppUserLogin, AppUserName, AppUserPwd, CreateTime, CreateBy, ModifyTime, ModifyBy, IsDelete  ");
            strSql.Append("  from AppUser ");
            strSql.Append(" where AppUserID=@AppUserID");
            List<DbParameter> parameters = new List<DbParameter>();

            AppUser r = new AppUser();
            r = _dalService.GetDataByReader<AppUser>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                r = null;
                if (dr.Read())
                {
                    r = new AppUser()
                    {
                        AppUserID = int.Parse(dr["AppUserID"].ToString()),

                        AppUserLogin = dr["AppUserLogin"].ToString(),

                        AppUserName = dr["AppUserName"].ToString(),

                        AppUserPwd = dr["AppUserPwd"].ToString(),

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
        internal static List<AppUser> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AppUser ");
            List<DbParameter> parameters = new List<DbParameter>();           
            return _dalService.GetListByReader<AppUser>(parameters, strSql.ToString(), delegate (DbDataReader dr) {
                List<AppUser> r = new List<AppUser>();
                while (dr.Read())
                {
                    r.Add(new AppUser()
                    {
                        AppUserID = int.Parse(dr["AppUserID"].ToString()),

                        AppUserLogin = dr["AppUserLogin"].ToString(),

                        AppUserName = dr["AppUserName"].ToString(),

                        AppUserPwd = dr["AppUserPwd"].ToString(),

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
