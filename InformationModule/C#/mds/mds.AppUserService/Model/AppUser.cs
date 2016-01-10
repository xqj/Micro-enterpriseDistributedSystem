using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;

namespace mds.AppUserService.Model
{
   public class AppUser: DataClassBase
    {
        public int AppUserID
        {
            set; get;
        }

        public int AppUserName
        {
            set; get;
        }

        public int LoginName
        {
            set; get;
        }

        public int LoginPwd
        {
            set; get;
        }
    }
}
