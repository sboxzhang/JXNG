using System;
using System.Data;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Resources;
namespace JITE.CIS.Framework.DBProviders
{
    /// <summary>
    /// 数据库执行类
    /// </summary>
    /// <remarks>
    /// 使用方法：<br/>
    /// 1、web.config配置<br/>
    ///    在"<configSections>"节点加入以下配置<br/>
    ///    <code>
    ///     <sectionGroup name="JITE.CIS.Framework">
    ///            <section name="DBProvider" requirePermission="false" type="JITE.CIS.Framework.DBProviders.DataBaseProviderConfigurationSection, JITE.CIS.Framework.DBProviders" allowDefinition="MachineToApplication" restartOnExternalChanges="true"/>
    ///    </sectionGroup>   
    ///    </code>
    ///    在"<configuration>"节点加入以下配置<br/>
    ///    <code>
    ///    <JITE.CIS.Framework>
    ///    <DBProvider defaultProvider="OracleDataBaseProvider" useLog="True" LogPath="~/App_Data/">
    ///  <!--参数说明:
	///		defaultProvider:使用哪种方式记录日志文件，与以下providers配置节的name相匹配
	///		useLog: 是否启用日志
    ///     logPath:日志存放位置
	///		-->
	///		<providers>
	///			<add name="OracleDataBaseProvider" type="JITE.CIS.Framework.DBProviders.OracleDataBaseProvider, JITE.CIS.Framework.DBProviders" connectionStringName="OracleProvider"/>
	///			<add name="SqlDataBaseProvider" type="JITE.CIS.Framework.DBProviders.SqlDataBaseProvider, JITE.CIS.Framework.DBProviders" connectionStringName="SqlProvider"/>
	///			<add name="OLEDataBaseProvider" type="JITE.CIS.Framework.DBProviders.OLEDataBaseProvider, JITE.CIS.Framework.DBProviders" connectionStringName="OLEDBProvider"/>
	///			<!--如要使用不同数据库，只需更改connectionStringName属性即可，对应以下connectionStrings节进行修改-->
	///		</providers>
	///	</DBProvider>
    /// </JITE.CIS.Framework>
    /// <connectionStrings>
	///	    <add name="SqlProvider" connectionString="server=.;uid=。。;pwd=。。;database=WinsonDB;" providerName="System.Data.SqlClient"/>
	///	    <add name="OLEDBProvider" connectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Web2.0\FrameWork\FrameWork.web\DataBase\Access\DBBack.mdb'" providerName="System.Data.OleDb"/>
	///	    <add name="OracleProvider" connectionString="Data Source=。。;User ID=。。;Password=。。" providerName="System.Data.OracleClient"/>
	/// </connectionStrings>
    /// </code>
    /// 2、使用方法<br/>
    ///    a、在业务类中引入JITE.CIS.Framework.DBProviders命名空间；
    ///    b、在需要进行日志记录的方法头上加入日志类标签，如
    ///       <code>
    ///         public bool ModifyMoudle(MoudleInfo info)
    ///         {
    ///             string Sql=".....";
    ///             return DataBaseManage.ExecuteSql(sql) > 0;
    ///         }
    ///       </code>
    /// </remarks>
    public static class DataBaseManage
    {
        private static object _lock = new object();
        private static DataBaseProvider _provider;
        private static DataBaseProviderCollection _providers;
        private static DataBaseProviderConfigurationSection _section;
        private static bool _useLog = true;

        [Logger]
        public static DataSet ExecuteDataSet(string SQLString)
        {
            return Provider.ExecuteDataSet(SQLString);
        }

        [Logger]
        public static DataSet ExecuteDataSet(string SQLString, params IDataParameter[] cmdParms)
        {
            return Provider.ExecuteDataSet(SQLString, cmdParms);
        }

        [Logger]
        public static DbDataReader ExecuteReader(string strSQL)
        {
            return Provider.ExecuteReader(strSQL);
        }

        [Logger]
        public static DbDataReader ExecuteReader(string SQLString, params IDataParameter[] cmdParms)
        {
            return Provider.ExecuteReader(SQLString, cmdParms);
        }

        [Logger]
        public static int ExecuteSql(string SQLString)
        {
            return Provider.ExecuteSql(SQLString);
        }

        [Logger]
        public static int ExecuteSql(string SQLString, params IDataParameter[] cmdParms)
        {
            return Provider.ExecuteSql(SQLString, cmdParms);
        }

        [Logger]
        public static int ExecuteSqlTran(List<string> SQLStringList)
        {
            return Provider.ExecuteSqlTran(SQLStringList);
        }

        [Logger]
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            Provider.ExecuteSqlTran(SQLStringList);
        }

        [Logger]
        public static IDbConnection GetdbConnection()
        {
            return Provider.GetdbConnection();
        }

        private static void GetProviders()
        {
            GenericCache<string, DataBaseProvider>.TryGetValue("DBProvider", out _provider);
            if (_provider == null)
            {
                lock (_lock)
                {
                    if (_provider == null)
                    {
                        _section = (DataBaseProviderConfigurationSection)ConfigurationManager.GetSection("JITE.CIS.Framework/DBProvider");
                        _providers = new DataBaseProviderCollection();
                        ProvidersHelper.InstantiateProviders(_section.Providers, _providers, typeof(DataBaseProvider));
                        _provider = _providers[_section.DefaultProvider];
                        GenericCache<string, DataBaseProvider>.Add("DBProvider", _provider);
                        if (_provider == null)
                        {
                            throw new ProviderException("不能获取默认的 DBProvider");
                        }
                    }
                }
            }
        }

        [Logger]
        public static object GetSingle(string SQLString, params IDataParameter[] cmdParms)
        {
            return Provider.GetSingle(SQLString, cmdParms);
        }

        [Logger]
        public static bool RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            return Provider.RunProcedure(storedProcName, parameters);
        }

        [Logger]
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            return Provider.RunProcedure(storedProcName, parameters, out rowsAffected);
        }

        [Logger]
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            return Provider.RunProcedure(storedProcName, parameters, tableName);
        }

        private static DataBaseProvider Provider
        {
            get
            {
                GetProviders();
                return _provider;
            }
        }

        private static DataBaseProviderCollection Providers
        {
            get
            {
                GetProviders();
                return _providers;
            }
        }
    }
}
