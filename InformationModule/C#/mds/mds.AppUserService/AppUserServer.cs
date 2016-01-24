using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.AppUserService.Core;
using mds.AppUserService.Model;
using mds.BaseModel;
using mds.Util;

namespace mds.AppUserService
{
    public class AppUserServer : IAppUserServer
    {
        public BaseModel.OperationResult<int> CreateUser(AppUser info)
        {
            return FunctionResultProxy.GetResult<OperationResult<int>>(delegate (OperationResult<int> r) {
                r.Data = AppUserDal.Create(info);
                r.ActionResult = (r.Data > 0);
                return r;
            });
        }
        public BaseModel.OperationMessage EditAppUser(AppUser info)
        {
            return FunctionResultProxy.GetResult<OperationMessage>(delegate (OperationMessage r)
            {
                r.ActionResult = (AppUserDal.Edit(info) > 0);
                return r;
            });
        }

        public BaseModel.OperationResult<AppUser> GetAppUser(int AppUserID)
        {
            return FunctionResultProxy.GetResult<OperationResult<AppUser>>(delegate (OperationResult<AppUser> r)
            {
                var sc = AppUserDal.Get(AppUserID);
                r.Data = sc;
                r.ActionResult = (r.Data != null);
                return r;
            });
        }
       
    }
}