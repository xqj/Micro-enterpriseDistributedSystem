using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;

namespace mds.AppUserService.Model
{
   public class AppUser: DataClassBase
    {
        /// <summary>
        /// auto_increment
        /// </summary>		
        public int AppUserID
        {
            set; get;
        }
        /// <summary>
        /// AppUserLogin
        /// </summary>		
        public string AppUserLogin
        {
            set; get;
        }
        /// <summary>
        /// AppUserName
        /// </summary>		
        public string AppUserName
        {
            set; get;
        }
        /// <summary>
        /// AppUserPwd
        /// </summary>		
        public string AppUserPwd
        {
            set; get;
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime
        {
            set; get;
        }
        /// <summary>
        /// CreateBy
        /// </summary>		
        public int CreateBy
        {
            set; get;
        }
        /// <summary>
        /// ModifyTime
        /// </summary>		
        public DateTime ModifyTime
        {
            set; get;
        }
        /// <summary>
        /// ModifyBy
        /// </summary>		
        public int ModifyBy
        {
            set; get;
        }
        /// <summary>
        /// IsDelete
        /// </summary>		
        public bool IsDelete
        {
            set; get;
        }
    }
}
