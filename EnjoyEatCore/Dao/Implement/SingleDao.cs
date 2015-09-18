using EnjoyEatCore.Dao.Base;
using EnjoyEatCore.Dao.Interface;
using EnjoyEatCore.Dao.Mapper;
using EnjoyEatCore.DomainObject.TableDomainObject;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Dao.Implement.SingleDao
{
    public class SingleDao : BaseDao, ISingleDao
    {
        #region InsertData

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="obj">資料物件</param>
        public void InsertData(object obj)
        {
            IDbParameters parameters = CreateDbParameters();
            StringBuilder sql = new StringBuilder();

            sql = SqlBuilder.Insert(obj);

            SetParameters(sql.ToString(), obj, ref parameters);

            base.ExecuteNonQuery(sql.ToString(), parameters);
        }

        #endregion InsertData

        #region DeleteData

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <param name="strFunctionName">Where條件的method name</param>
        public void DeleteData(object obj, string strFunctionName = "PK_")
        {
            IDbParameters parameters = CreateDbParameters();
            StringBuilder sql = new StringBuilder();

            sql = SqlBuilder.Delete(obj, strFunctionName);

            SetParameters(sql.ToString(), obj, ref parameters);

            base.ExecuteNonQuery(sql.ToString(), parameters);
        }

        #endregion DeleteData

        #region UpdateData

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <param name="strArray">強制欄位設定</param>
        /// <param name="strFunctionName">Where條件的method name</param>
        public void UpdateData(object obj, string[] strArray = null, string strFunctionName = "PK_")
        {
            IDbParameters parameters = CreateDbParameters();
            StringBuilder sql = new StringBuilder();

            sql = SqlBuilder.Update(obj, strFunctionName);

            SetParameters(sql.ToString(), obj, ref parameters);

            base.ExecuteNonQuery(sql.ToString(), parameters);
        }

        #endregion UpdateData

        #region ReadData

        /// <summary>
        /// 根據傳入的DOMAIN產生撈取語法
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <param name="strOrderByField">OrderBy條件</param>
        /// <param name="strFunctionName">Where條件的method name</param>
        public IList<T> ReadData<T>(T obj, string[] strOrderByField = null, string strFunctionName = "PK_")
        {
            IDbParameters parameters = CreateDbParameters();
            StringBuilder strSql = new StringBuilder();
            int index_1 = 0;
            string strTag = "@";
            strSql = SqlBuilder.Query(obj);

            //根據strFunctionName產生where條件

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

            if (!string.IsNullOrEmpty(strFunctionName))
            {
                //取得物件的Funtion
                foreach (MethodInfo objMethod in obj.GetType().GetMethods())
                {
                    if (objMethod.Name == strFunctionName)
                    {
                        foreach (ParameterInfo objParameter in objMethod.GetParameters())
                        {
                            strSql.AppendLine("AND " + objParameter.Name + " = " + strTag + objParameter.Name + " ");
                        }
                    }
                }
            }

            //根據FunctionName的傳入參數組出OrderBy條件
            if (strOrderByField != null)
            {
                foreach (string field in strOrderByField)
                {
                    if (index_1 == 0)
                    {
                        strSql.AppendLine("ORDER BY ");
                        strSql.AppendLine(field + " ");
                    }
                    else
                    {
                        strSql.AppendLine(", " + field + " ");
                    }
                    index_1 = 1;
                }
            }

            SetParameters(strSql.ToString(), obj, ref parameters);

            return base.QueryWithRowMapper<T>(CommandType.Text, Convert.ToString(strSql), new GenerateRowMapper<T>(), parameters);
        }

        ///// <summary>
        ///// 根據傳入的DOMAIN產生撈取語法(無參數)
        ///// </summary>
        ///// <param name="obj">資料物件</param>
        ///// <param name="strOrderByField">OrderBy條件</param>
        ///// <param name="strTableSourceFlag">來源Table的註記</param>
        //public IList<T> ReadDataNoTerm<T>(T obj, string[] strOrderByField = null, string strTableSourceFlag = "")
        //{
        //    IDbParameters parameters = CreateDbParameters();
        //    StringBuilder sql = new StringBuilder();

        //    sql = SqlBuilder.Query(obj, strOrderByField, strTableSourceFlag);

        //    SetParameters(sql.ToString(), obj, ref parameters);

        //    return base.QueryWithRowMapper<T>(CommandType.Text, Convert.ToString(sql), new GenerateRowMapper<T>(), parameters);
        //}

        #endregion ReadData
    }
}