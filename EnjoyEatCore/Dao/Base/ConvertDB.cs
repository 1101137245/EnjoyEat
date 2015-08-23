using EnjoyEatCore.DomainObject.TableDomainObject;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EnjoyEatCore.Dao.Base
{
    public partial class BaseDao : AdoDaoSupport
    {
       
        public static class ConvertDBObject
        {
            /// <summary>
            /// 轉型成字串
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static string ConvertString(object obj)
            {
                return Convert.IsDBNull(obj) || obj == null ? string.Empty : Convert.ToString(obj).Trim();
            }

            /// <summary>
            /// 轉型成整數
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static int? ConvertInt(object obj)
            {
                if (Convert.IsDBNull(obj) || obj == null) return null;

                return Convert.ToInt32(obj);
            }

            /// <summary>
            /// 轉型成精準度的浮點數
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static decimal? ConvertDecimal(object obj)
            {
                if (Convert.IsDBNull(obj) || obj == null) return null;

                return Convert.ToDecimal(obj);
            }

            /// <summary>
            /// 轉型成浮點數
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static double? ConvertDouble(object obj)
            {
                if (Convert.IsDBNull(obj) || obj == null) return null;

                return Convert.ToDouble(obj);
            }

            /// <summary>
            /// 轉型成日期
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static DateTime? ConvertDate(object obj)
            {
                if (Convert.IsDBNull(obj) || obj == null) return null;

                return Convert.ToDateTime(obj);
            }
        }

        public static class ConvertDbType
        {
            public static DbType GetDbType(string strPropertyTypeName)
            {
                DbType objType = new DbType();

                switch (strPropertyTypeName)
                {
                    case "String":
                        objType = DbType.String;
                        break;

                    case "int":
                        objType = DbType.Int32;
                        break;

                    case "DateTime":
                        objType = DbType.Date;
                        break;

                    default:
                        break;
                }
                return objType;
            }
        }

        
    }
}