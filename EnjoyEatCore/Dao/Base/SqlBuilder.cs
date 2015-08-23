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
        public class SqlBuilder
        {
            public static StringBuilder Query(object obj, string[] strOrderByField = null, string strTableSourceFlag = "")
            {
                BaseDao objBaseDao = new BaseDao();
                StringBuilder strSql = new StringBuilder();
                string strTableName = string.Empty;
                int index = 0;
                int index_1 = 0;
                strSql.AppendLine("SELECT ");

                foreach (PropertyInfo objItem  in obj.GetType().GetProperties())
                {
                    //將TABLE_NAME記錄至strTableName中
                    if (objItem.Name == "TABLE_NAME")
                    {
                        strTableName = objItem.GetValue(obj, null).ToString() + strTableSourceFlag;
                    }
                    else
                    {
                        if (index == 0)
                        {
                            strSql.AppendLine(" " + objItem.Name + " ");
                        }
                        else
                        {
                            strSql.AppendLine(" , " + objItem.Name + " ");
                        }

                        index = 1;
                    }
                }

                strSql.AppendLine("FROM " + strTableName + "");
                strSql.AppendLine("WHERE 1=1");

                if (strOrderByField != null)
                {
                    foreach (string field in strOrderByField)
                    {
                        if (index_1 == 0)
                        {
                            strSql.AppendLine(" ORDER BY ");
                            strSql.AppendLine(field + " ");
                        }
                        else
                        {
                            strSql.AppendLine(" , " + field + " ");
                        }
                        index_1 = 1;
                    }
                }

                return strSql;
            }

            /// <summary>
            /// Insert
            /// </summary>
            /// <param name="obj">資料物件</param>
            /// <returns></returns>
            public static StringBuilder Insert(object obj)
            {
                BaseDao objBaseDao = new BaseDao();
                StringBuilder strSql = new StringBuilder();
                string strTableName = string.Empty;
                string strTag = "@";
                StringBuilder strFieldName = new StringBuilder();
                StringBuilder strParameter = new StringBuilder();
                string strDateString = "GETDATE()";
                int index = 0;

                foreach (PropertyInfo objItem in obj.GetType().GetProperties())
                {
                    //將TABLE_NAME記錄至strTableName中
                    if (objItem.Name == "TABLE_NAME")
                    {
                        strTableName = objItem.GetValue(obj, null).ToString();
                    }
                    else
                    {
                        if (objItem.GetValue(obj, null) != null && objItem.Name != "TABLE_NAME")
                        {
                            if (index == 0)
                            {
                                if (objItem.GetValue(obj, null) != null && objItem.GetValue(obj, null).ToString() == strDateString)
                                {
                                    strFieldName.AppendLine("     " + objItem.Name);
                                    strParameter.AppendLine("     " + strDateString);
                                }
                                else
                                {
                                    strFieldName.AppendLine("     " + objItem.Name);
                                    strParameter.AppendLine("     " + strTag + objItem.Name);
                                }
                            }
                            else
                            {
                                if (objItem.GetValue(obj, null) != null && objItem.GetValue(obj, null).ToString() == strDateString)
                                {
                                    strFieldName.AppendLine("   , " + objItem.Name);
                                    strParameter.AppendLine("   , " + strDateString);
                                }
                                else
                                {
                                    strFieldName.AppendLine("   , " + objItem.Name);
                                    strParameter.AppendLine("   , " + strTag + objItem.Name);
                                }
                            }
                            index = 1;
                        }
                    }
                }

                strSql.AppendLine("INSERT INTO " + strTableName + " ");
                strSql.AppendLine(" ( ");
                strSql.AppendLine(strFieldName.ToString());
                strSql.AppendLine(" )");
                strSql.AppendLine("VALUES");
                strSql.AppendLine(" ( ");
                strSql.AppendLine(strParameter.ToString());
                strSql.AppendLine(" )");

                return strSql;
            }

            /// <summary>
            /// Update
            /// </summary>
            /// <param name="obj">資料物件</param>
            /// <param name="strFunctionName">Where條件的method name</param>
            /// <returns></returns>
            public static StringBuilder Update(object obj, string strFunctionName = "PK_")
            {
                BaseDao objBaseDao = new BaseDao();
                StringBuilder strSql = new StringBuilder();
                string strTableName = string.Empty;
                StringBuilder strParameter = new StringBuilder();
                string strTag = "@";
                List<string> liPrimaryKey = new List<string>();     //暫存PK值
                int index = 0;
                string strDateString = "GETDATE()";

                //取得物件的PK值
                foreach (MethodInfo objMethod in obj.GetType().GetMethods())
                {
                    if (objMethod.Name.Substring(0, 3) == "PK_")
                    {
                        if (strFunctionName == "PK_")
                        {
                            strFunctionName = objMethod.Name;
                        }

                        foreach (ParameterInfo objParameter in objMethod.GetParameters())
                        {
                            liPrimaryKey.Add(objParameter.Name);
                        }
                    }
                }

                //設定Update語法
                foreach (PropertyInfo objItem in obj.GetType().GetProperties())
                {
                    //將TABLE_NAME記錄至strTableName中
                    if (objItem.Name == "TABLE_NAME")
                    {
                        strTableName = objItem.GetValue(obj, null).ToString();
                    }
                    else
                    {
                        if (objItem.GetValue(obj, null) != null && objItem.Name != "TABLE_NAME")
                        {
                            if (index == 0)
                            {
                                if (objItem.GetValue(obj, null) != null && objItem.GetValue(obj, null).ToString() == strDateString)
                                {
                                    strParameter.AppendLine(objItem.Name + "= " + strDateString);
                                }
                                else
                                {
                                    strParameter.AppendLine(objItem.Name + "= " + strTag + objItem.Name);
                                }
                            }
                            else
                            {
                                if (objItem.GetValue(obj, null) != null && objItem.GetValue(obj, null).ToString() == strDateString)
                                {
                                    strParameter.AppendLine(" , " + objItem.Name + "= " + strDateString);
                                }
                                else
                                {
                                    strParameter.AppendLine(" , " + objItem.Name + "= " + strTag + objItem.Name);
                                }
                            }
                            index = 1;
                        }
                    }
                }

                strSql.AppendLine("UPDATE " + strTableName + " ");
                strSql.AppendLine("SET ");
                strSql.AppendLine(strParameter.ToString());
                strSql.AppendLine(" WHERE 1=1");

                //根據FunctionName的傳入參數組出Where條件
                if (!string.IsNullOrEmpty(strFunctionName))
                {
                    //取得物件的Funtion
                    foreach (MethodInfo objMethod in obj.GetType().GetMethods())
                    {
                        if (objMethod.Name == strFunctionName)
                        {
                            foreach (ParameterInfo objParameter in objMethod.GetParameters())
                            {
                                strSql.AppendLine(" AND " + objParameter.Name + " = " + strTag + objParameter.Name);
                            }
                        }
                    }
                }

                return strSql;
            }

            /// <summary>
            /// Delete
            /// </summary>
            /// <param name="obj">資料物件</param>
            /// <returns></returns>
            public static StringBuilder Delete(object obj, string strFunctionName = "PK_")
            {
                BaseDao objBaseDao = new BaseDao();
                StringBuilder strSql = new StringBuilder();
                string strTableName = string.Empty;
                string strTag = "@";

                foreach (PropertyInfo objItem in obj.GetType().GetProperties())
                {
                    if (objItem.Name == "TABLE_NAME")
                    {
                        strTableName = objItem.GetValue(obj, null).ToString();
                    }
                }

                strSql.AppendLine("DELETE " + strTableName);
                strSql.AppendLine("WHERE 1=1 ");

                //若strFunctionName為empty或null,則預設為該物件PK_開頭的method name
                if (strFunctionName == "PK_")
                {
                    foreach (MethodInfo objMethod in obj.GetType().GetMethods())
                    {
                        if (objMethod.Name.Substring(0, 3) == "PK_")
                        {
                            strFunctionName = objMethod.Name;
                        }
                    }
                }

                //根據FunctionName的傳入參數組出Where條件
                if (!string.IsNullOrEmpty(strFunctionName))
                {
                    //取得物件的Funtion
                    foreach (MethodInfo objMethod in obj.GetType().GetMethods())
                    {
                        if (objMethod.Name == strFunctionName)
                        {
                            foreach (ParameterInfo objParameter in objMethod.GetParameters())
                            {
                                strSql.AppendLine(" AND " + objParameter.Name + " = " + strTag + objParameter.Name);
                            }
                        }
                    }
                }

                return strSql;
            }
        }
    }
}