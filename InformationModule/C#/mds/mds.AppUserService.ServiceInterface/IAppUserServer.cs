using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.AppUserService.Model;

namespace mds.AppUserService
{
    public interface IAppUserServer
    {
        BaseModel.OperationResult<int> CreateUser(AppUser info);
         BaseModel.OperationMessage EditAppUser(AppUser info);

         BaseModel.OperationResult<AppUser> GetAppUser(int AppUserID);
    }
}