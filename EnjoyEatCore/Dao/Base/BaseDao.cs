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
    public class BaseDao : AdoDaoSupport
    {
        public static object GetRowMapperObject(object obj, IDataReader dataReader)
        {
            string typeName = string.Empty;

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (!Convert.IsDBNull(dataReader[i]))
                {
                    foreach (PropertyInfo objItem in obj.GetType().GetProperties())
                    {
                        if (objItem.Name == dataReader.GetName(i))
                        {
                            typeName = objItem.PropertyType.Name.ToLower();

                            //判斷domain object是否設定為nullable, 若是則需要取得其基底型別
                            if (typeName == "nullable`1")
                            {
                                typeName = Nullable.GetUnderlyingType(objItem.PropertyType).Name.ToLower();
                            }

                            switch (typeName)
                            {
                                case "string":
                                    objItem.SetValue(obj, ConvertDBObject.ConvertString(dataReader[i]), null);
                                    break;

                                case "int":
                                    objItem.SetValue(obj, ConvertDBObject.ConvertInt(dataReader[i]), null);
                                    break;

                                case "decimal":
                                    objItem.SetValue(obj, ConvertDBObject.ConvertDecimal(dataReader[i]), null);
                                    break;

                                case "double":
                                    objItem.SetValue(obj, ConvertDBObject.ConvertDouble(dataReader[i]), null);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            return obj;
        }

        public IList<T> QueryWithRowMapper<T>(CommandType cmdType, string cmdText, IRowMapper<T> rowMapper)
        {
            return this.AdoTemplate.QueryWithRowMapper<T>(CommandType.Text, cmdText, rowMapper);
        }

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

        public class GenerateRowMapper<T> : IRowMapper<T>
        {
            public T MapRow(IDataReader dataReader, int rowNum)
            {
                object obj = Activator.CreateInstance(typeof(T));
                return (T)GetRowMapperObject(obj, dataReader);
            }
        }
    }
}