using System;
using System.Configuration;

namespace JITE.CIS.Framework.DBProviders
{
    partial class DataBaseProviderConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// DataBase的默认的Provider
        /// </summary>
        [StringValidator(MinLength = 1)]
        [ConfigurationProperty("defaultProvider", DefaultValue = "OracleDataBaseProvider")]
        public string DefaultProvider
        {
            get { return (string)base["defaultProvider"]; }
            set { base["defaultProvider"] = value; }
        }
        /// <summary>
        /// 是否使用异常日志
        /// </summary>
        [StringValidator(MinLength = 1)]
        [ConfigurationProperty("useLog", DefaultValue = "true")]
        public string UseLog
        {
            get { return (string)base["useLog"]; }
            set { base["useLog"] = value; }
        }
        /// <summary>
        /// 日志存放路径
        /// </summary>
        [StringValidator(MinLength = 1)]
        [ConfigurationProperty("LogPath", DefaultValue = "~/App_Data/")]
        public string LogPath
        {
            get { return (string)base["LogPath"]; }
            set { base["LogPath"] = value; }
        }
        /// <summary>
        /// DataBase的所有的Provider集合
        /// </summary>
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection)base["providers"]; }
        }

    }
}