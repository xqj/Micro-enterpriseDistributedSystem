using mds.BaseModel;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace mds.ConfigClient
{
    public class ConfigServiceClient
    {
        private SolutionConfiguration _solutionConfig;
        public ConfigServiceClient()
        {
            _solutionConfig = new SolutionConfiguration()
            {
                Components = new List<ComponentConfiguration>(),
                Content = "",
                IsRemote = false,
                SolutionId = Guid.Empty,
                Enable = true,
                IsActive = true,
                Environment = 0,
                IsDelete = false,
                IsFile = true,
                SolutionName = "本地配置",
                Status = 1,
                Version = 0

            };//构造函数默认对象内属性数值，默认为本地模式参数
        }
        public InitResult Init()
        {
            var r = new InitResult() { Result = true };
            AppConfiguration appConfig = null;
            try
            {
                appConfig = ReadAppConfig();//防止基础配置不存在或者错误导致程序无法启动
            }
            catch (Exception ex)
            {
                appConfig = new AppConfiguration() { IsFileLoad = true, Version = 0, SolutionId = Guid.Empty, IsRemote = false};//错误配置下给予最小化配置
                r.Result = false;
                r.Message = ex.Message;
            }
            if (appConfig.IsRemote)//判断是否读取远程配置模式
            {
                ReadRemote(appConfig);//读取远程配置
            }
            else
            {
                ReadLocal(appConfig,r);//读取本地配置
            }
            return r;
        }
        /// <summary>
        /// 本地配置模式下只有一个方案序列化文件
        /// </summary>
        /// <param name="appConfig"></param>
        private void ReadLocal(AppConfiguration appConfig,InitResult result)
        {
            if (string.IsNullOrEmpty(appConfig.LocalConfigFilePath))//如果没有默认路径不读取
            {
                result.Result = false;
                result.Message ="本地配置文件路径为空";
                return;//构造函数里默认数值
            }
            try
            {
              var temp=XmlConfigSerializer.Instance.DeserializeSingle<SolutionConfiguration>(appConfig.LocalConfigFilePath);
              if (temp != null)//使用构造函数里的数值，避免多位置同效代码赋值
              {
                  _solutionConfig = temp;
              }
            }
            catch (Exception ex)//预期异常：格式错误，错误内容
            {
                result.Result = false;
                result.Message = ex.Message;
                return;
            }

        }

        private void ReadRemote(AppConfiguration appConfig)
        {

            if (appConfig.IsFileLoad)
            { //非内存加载模式

            }

        }

        private AppConfiguration ReadAppConfig()
        {
            return new AppConfiguration()
            {
                IsFileLoad = bool.Parse(ConfigurationManager.AppSettings[DefineTable.IsFileLoad]),
                IsRemote = bool.Parse(ConfigurationManager.AppSettings[DefineTable.IsRemote]),
                SolutionId = Guid.Parse(ConfigurationManager.AppSettings[DefineTable.SolutionId]),
                Version = int.Parse(ConfigurationManager.AppSettings[DefineTable.SolutionVersion]),
                RemoteConfigServer = ConfigurationManager.AppSettings[DefineTable.RemoteConfigServerUrl]
            };
        }


    }
    public class InitResult
    {
        public bool Result { set; get; }
        public string Message { set; get; }
    }
}
