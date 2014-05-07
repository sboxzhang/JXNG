using System;
using PostSharp.Laos;
using System.Xml;
using System.IO;
using System.Reflection;
using Thread = System.Threading.Thread;
using System.Configuration;
namespace JITE.CIS.Framework.DBProviders
{
    [Serializable]
    [global::System.AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class LoggerAttribute : OnMethodBoundaryAspect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnSuccess(MethodExecutionEventArgs eventArgs)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "\\App.config";
            Configuration AppConfig = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            DataBaseProviderConfigurationSection _section = (DataBaseProviderConfigurationSection)ConfigurationManager.GetSection("JITE.CIS.Framework/DBProvider");
            if (!Convert.ToBoolean(_section.UseLog))
                return;
            ParameterInfo[] ps = eventArgs.Method.GetParameters();
            object[] pv = eventArgs.GetWritableArgumentArray();
            string parameList = "[";
            for (int i = 0; i < ps.Length; i++)
            {
                Console.WriteLine(" {0}={1}", ps[i].Name, pv[i]);
                parameList += ps[i].Name + "=" + pv[i] + ";";
            }
            parameList += "]";
            OutputErrLog(eventArgs.Method.Name, parameList, "false", eventArgs.Exception, _section.LogPath);
        }
        public override void OnException(MethodExecutionEventArgs eventArgs)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "\\App.config";
            Configuration AppConfig = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            DataBaseProviderConfigurationSection _section = (DataBaseProviderConfigurationSection)ConfigurationManager.GetSection("JITE.CIS.Framework/DBProvider");
            if (!Convert.ToBoolean(_section.UseLog))
                return;
            ParameterInfo[] ps = eventArgs.Method.GetParameters();
            object[] pv = eventArgs.GetWritableArgumentArray();
            string parameList = "[";
            for (int i = 0; i < ps.Length; i++)
            {
                Console.WriteLine(" {0}={1}", ps[i].Name, pv[i]);
                parameList += ps[i].Name + "=" + pv[i] + ";";
            }
            parameList += "]";
            OutputErrLog(eventArgs.Method.Name, parameList, "true", eventArgs.Exception, _section.LogPath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="parametersList"></param>
        /// <returns></returns>
        private bool OutputErrLog(string methodName, string parametersList, string IsException, Exception exception, string LogPath)
        {
            

            string _logPath = "";
            if (LogPath.StartsWith("~/"))
                _logPath = MapPath(LogPath);
            string strFile = _logPath + String.Format("{0:yyyyMMdd}", DateTime.Today) + "_DBLog.xml";
            if (!File.Exists(strFile))
                return CreateLog(strFile, methodName, parametersList, IsException, exception);
            else
                return AppendLog(strFile, methodName, parametersList, IsException, exception);
        }

        #region 私有方法
        private string MapPath(string path)
        {
            return System.Web.Hosting.HostingEnvironment.MapPath(path);
        }
        /// <summary>
        /// 创建日志文件
        /// </summary>
        /// <param name="logFile">日志文件</param>
        /// <param name="methodName">异常方法</param>
        /// <param name="parametersList">异常参数</param>
        /// <param name="exception">异常</param>
        /// <returns></returns>
        private bool CreateLog(string logFile, string methodName, string parametersList, string IsException, Exception exception)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(logFile, System.Text.Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 4;
                    writer.WriteStartDocument(true);
                    writer.WriteStartElement("SQL语句执行记录");
                    writer.WriteAttributeString("执行日期", String.Format("{0:yyyy-MM-dd}", DateTime.Today));

                    writer.WriteStartElement("时间");
                    writer.WriteAttributeString("Value", DateTime.Now.ToShortTimeString());


                    writer.WriteStartElement("方法");
                    writer.WriteValue(methodName);
                    writer.WriteEndElement();

                    writer.WriteStartElement("参数");
                    writer.WriteValue(parametersList);
                    writer.WriteEndElement();

                    writer.WriteStartElement("执行人");
                    writer.WriteValue(Thread.CurrentPrincipal.Identity.Name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("是否异常");
                    writer.WriteValue(IsException);
                    writer.WriteEndElement();

                    writer.WriteStartElement("错误信息");
                    if (exception != null)
                        writer.WriteValue(exception.Message);
                    writer.WriteEndElement();

                    writer.WriteStartElement("错误跟踪信息");
                    if (exception != null)
                        writer.WriteValue(exception.StackTrace);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// 追加到日志文件
        /// </summary>
        /// <param name="logFile">日志文件</param>
        /// <param name="methodName">异常方法</param>
        /// <param name="parametersList">异常参数</param>
        /// <param name="exception">异常</param>
        /// <returns></returns>
        private bool AppendLog(string logFile, string methodName, string parametersList, string IsException, Exception exception)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                using (XmlTextReader reader = new XmlTextReader(logFile))
                {
                    doc.Load(reader);

                    XmlElement root = doc.DocumentElement;   //   获取根节点  


                    XmlElement eDate = doc.CreateElement("时间");
                    XmlElement eMethod = doc.CreateElement("方法");
                    XmlElement eParames = doc.CreateElement("参数");
                    XmlElement eUser = doc.CreateElement("执行人");
                    XmlElement eIsException = doc.CreateElement("是否异常");
                    XmlElement eMsg = doc.CreateElement("异常信息");
                    XmlElement eTrace = doc.CreateElement("异常跟踪信息");


                    eDate.SetAttribute("Value", DateTime.Now.ToShortTimeString());
                    eMethod.InnerText = methodName;
                    eParames.InnerText = parametersList;
                    eUser.InnerText = Thread.CurrentPrincipal.Identity.Name;
                    eIsException.InnerText = IsException;
                    if (exception != null)
                    {
                        eMsg.InnerText = exception.Message;
                        eTrace.InnerText = exception.StackTrace;
                    }

                    eDate.AppendChild(eMethod);
                    eDate.AppendChild(eParames);
                    eDate.AppendChild(eUser);
                    eDate.AppendChild(eIsException);
                    eDate.AppendChild(eMsg);
                    eDate.AppendChild(eTrace);

                    root.AppendChild(eDate);
                }
                doc.Save(logFile);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }

}
