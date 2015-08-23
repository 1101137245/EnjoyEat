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
        private string strDelimited = "[^0-9A-Za-z_$]";

        /// <summary>
        /// 檢核PropertyName是否存在且具有資料
        /// </summary>
        /// <param name="obj">data object</param>
        /// <param name="dataReader">The data reader</param>
        /// <returns>Boolean</returns>
        /// <history>
        /// </history>
        

        public IList<T> QueryWithRowMapper<T>(CommandType cmdType, string cmdText, IRowMapper<T> rowMapper)
        {
            return this.AdoTemplate.QueryWithRowMapper<T>(CommandType.Text, cmdText, rowMapper);
        }

        public IList<T> QueryWithRowMapper<T>(CommandType cmdType, string cmdText, IRowMapper<T> rowMapper, IDbParameters parameters)
        {
            return this.AdoTemplate.QueryWithRowMapper<T>(CommandType.Text, cmdText, rowMapper, parameters);
        }

        public void ExecuteNonQuery(string command, IDbParameters parameters)
        {
            AdoTemplate.ExecuteNonQuery(CommandType.Text, command, parameters);
        }

        /// <summary>
        /// 設定參數
        /// </summary>
        /// <param name="strSql">SQL</param>
        /// <param name="obj">參數物件</param>
        /// <param name="parameters"></param>
        /// <history>
        /// </history>
        public void SetParameters(string strSql, object obj, ref IDbParameters parameters)
        {
            string strTag = "@";

            if (obj != null)
            {
                foreach (PropertyInfo objItem in obj.GetType().GetProperties())
                {
                    for (int i = 0; i < Regex.Matches(strSql, strTag + objItem.Name + strDelimited).Count; i++)
                    {
                        object temp = objItem.GetValue(obj, null);
                        if (objItem.GetValue(obj, null) != null)
                        {
                            parameters.Add(objItem.Name, ConvertDbType.GetDbType(objItem.PropertyType.Name)).Value = objItem.GetValue(obj, null) == null ? DBNull.Value : objItem.GetValue(obj, null);
                        }
                    }
                }
            }
        }

        
    }
}