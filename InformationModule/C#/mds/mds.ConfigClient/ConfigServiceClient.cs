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
        /// <summary>
        /// 在程序第一次运行时运行此方法获取配置
        /// </summary>
        /// <returns></returns>
        public InitResult RunInAppStartInit()
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
            ReadLocal(appConfig,r);//读取本地配置 
            return r;
        }
        public ComponentConfiguration GetComponentConfig(int componetID)
        {
            //构造函数完成无null初始化设置
            return _solutionConfig.Components.Find(c => c.ComponentId == componetID);
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
        private SolutionConfiguration ReadLocal(AppConfiguration appConfig)
        {
            if (string.IsNullOrEmpty(appConfig.LocalConfigFilePath))//如果没有默认路径不读取
            {               
                return null;//构造函数里默认数值
            }
            try
            {
                var temp = XmlConfigSerializer.Instance.DeserializeSingle<SolutionConfiguration>(appConfig.LocalConfigFilePath);
                return temp;
            }
            catch (Exception ex)//预期异常：格式错误，错误内容
            {              
                
            }
            return null;
        }
        private void ReadRemote(AppConfiguration appConfig)
        {

            if (appConfig.IsFileLoad)
            {
                SolutionConfiguration localconfig = null;
                //判断配置文件是否已经存在
                if (File.Exists(appConfig.LocalConfigFilePath))
                {                   
                    localconfig = ReadLocal(appConfig);
                }
                //远程拉取配置文件
                var remoteConfig = GetRemote(appConfig.RemoteConfigServer, appConfig.SolutionId, appConfig.Version);
               //判断配置文件的新鲜程度
                if (remoteConfig != null)//无法获取远程配置时不更新本地
                {
                    if(remoteConfig.Version==0)//永远最新
                    {
                        File.Delete(appConfig.LocalConfigFilePath);
                        //固化指定目录下制定的文件
                        File.AppendAllText(appConfig.LocalConfigFilePath, XmlConfigSerializer.Instance.ToXml(remoteConfig));
                    }
                    if ((remoteConfig.Version> 0)&&(localconfig == null))//本地没有配置文件并且不是永远更新
                    {
                        File.AppendAllText(appConfig.LocalConfigFilePath, XmlConfigSerializer.Instance.ToXml(remoteConfig));
                    }
                }               
            }
        }
        private SolutionConfiguration GetRemote(string url,Guid solutionID,int version)
        {
            var dic = new Dictionary<string, string>();
            dic.Add(DefineTable.SolutionIDParam, solutionID.ToString());
            dic.Add(DefineTable.VersionParam, version.ToString());
            string str = "";
            try {
                str = HttpRequestHelper.Instance.GetNormalRequestResult(url, dic);
            }catch(Exception ex)
            {
                return null; 
            }
            return XmlConfigSerializer.Instance.FromXml<SolutionConfiguration>(str);
        }
        private AppConfiguration ReadAppConfig()
        {
            return new AppConfiguration()
            {
                IsFileLoad = bool.Parse(ConfigurationManager.AppSettings[DefineTable.IsFileLoad]),
                IsRemote = bool.Parse(ConfigurationManager.AppSettings[DefineTable.IsRemote]),
                SolutionId = Guid.Parse(ConfigurationManager.AppSettings[DefineTable.SolutionId]),
                Version = int.Parse(ConfigurationManager.AppSettings[DefineTable.SolutionVersion]),
                RemoteConfigServer = ConfigurationManager.AppSettings[DefineTable.RemoteConfigServerUrl],
                 LocalConfigFilePath = ConfigurationManager.AppSettings[DefineTable.LocalConfigFilePath],
                  AppID=int.Parse(ConfigurationManager.AppSettings[DefineTable.AppID])
            };
        }


    }
    public class InitResult
    {
        public bool Result { set; get; }
        public string Message { set; get; }
    }
}
