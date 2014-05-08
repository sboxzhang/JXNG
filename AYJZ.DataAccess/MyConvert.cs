using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSM.DataAccess
{
    /// <summary>
    /// 自定义数据转换
    /// </summary>
    public class MyConvert
    {

        /// <summary>
        /// 转换为Decimal
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object objValue)
        {
            if (objValue != null)
            {
                if (objValue.ToString().Trim() == "")
                    return 0;
            }
            try
            {
                return Convert.IsDBNull(objValue) ? 0 : Convert.ToDecimal(objValue);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为string
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static string ToString(object objValue)
        {
            try
            {
                return Convert.IsDBNull(objValue) ? "" : objValue.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static long ToLong(object objValue)
        {
            if (objValue != null)
            {
                if (objValue.ToString().Trim() == "")
                    return 0;
            }
            try
            {
                return Convert.IsDBNull(objValue) ? 0 : Convert.ToInt64(Convert.ToSingle(objValue));
            }
            catch
            {
                return 0;
            }
        }
        
        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static short ToInt(object objValue)
        {
            if (objValue != null)
            {
                if (objValue.ToString().Trim() == "")
                    return (short)0;
            }
            try
            {
                return Convert.IsDBNull(objValue) ? (short)0 : (short)Convert.ToInt32(Convert.ToSingle(objValue));
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static short ToInt32(object objValue)
        {
            if (objValue != null)
            {
                if (objValue.ToString().Trim() == "")
                    return (short)0;
            }
            try
            {
                return Convert.IsDBNull(objValue) ? (short)0 : (short)Convert.ToInt32(Convert.ToSingle(objValue));
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 转换为Int16
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static short ToInt16(object objValue)
        {
            if (objValue != null)
            {
                if (objValue.ToString().Trim() == "")
                    return (short)0;
            }
            try
            {
                return Convert.IsDBNull(objValue) ? (short)0 : (short)Convert.ToInt32(Convert.ToSingle(objValue));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为Single
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static Single ToSingle(object objValue)
        {
            return Convert.IsDBNull(objValue) ? 0 : Convert.ToSingle(objValue);
        }

        /// <summary>
        /// 转换为Single
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static double ToDouble(object objValue)
        {
            try
            {
                return Convert.IsDBNull(objValue) ? 0 : Convert.ToDouble(objValue);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为Boolean
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(object objValue)
        {
            if (Convert.IsDBNull(objValue))
                return false;

            if (objValue.ToString() == "是")
                return true;
            else
            {
                try
                {
                    return Convert.ToBoolean(objValue);
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 转换为DateTime
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static Nullable<DateTime> ToDateTime(object objValue)
        {
            if (Convert.IsDBNull(objValue)) return null;
            else return Convert.ToDateTime(objValue);
        }

        static readonly DateTime march1st1900 = new DateTime(1900, 03, 01);
        static readonly DateTime december31st1899 = new DateTime(1899, 12, 31);
        static readonly TimeSpan after1stMarchAdjustment = new TimeSpan(1, 0, 0, 0);

        /// <summary>
        /// 把Excel中独处的时间转换为DateTime
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromExcel(object objValue)
        {
            if (Convert.IsDBNull(objValue))
                return new DateTime(1900, 1, 1);

            string excelDate = objValue.ToString();
            TimeSpan ts = TimeSpan.Parse(excelDate);
            DateTime dt = december31st1899 + ts;

            if (dt >= march1st1900)
            {
                return dt - after1stMarchAdjustment;
            }
            return dt;
        }
    }
}

