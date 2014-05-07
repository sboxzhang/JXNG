using System;
using System.Configuration.Provider;

namespace JITE.CIS.Framework.DBProviders
{
    partial class DataBaseProviderCollection : ProviderCollection
    {
        /// <summary>
        /// 通过name获取provider
        /// </summary>
        public new DataBaseProvider this[string name]
        {
            get { return (DataBaseProvider)base[name]; }
        }

        /// <summary>
        /// 向集合中添加提供程序。
        /// </summary>
        /// <param name="provider">要添加的提供程序。</param>
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider参数不能为null");

            if (!(provider is DataBaseProvider))
                throw new ArgumentException("provider参数类型必须是DataBaseProvider.");

            base.Add(provider);
        }
    }
}
