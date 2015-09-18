using EnjoyEatCore.DomainObject.TableDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Dao.Interface
{
    public interface ISingleDao
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="obj">資料物件</param>
        void InsertData(object obj);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <param name="strFunctionName">Where條件的method name</param>
        void DeleteData(object obj, string strFunctionName = "PK_");

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <param name="strArray">強制欄位設定</param>
        /// <param name="strFunctionName">Where條件的method name</param>
        void UpdateData(object obj, string[] strArray = null, string strFunctionName = "PK_");

        /// <summary>
        /// 根據傳入的DOMAIN產生撈取語法
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <param name="strFunctionName">Where條件的method name</param>
        IList<T> ReadData<T>(T obj, string[] strOrderByField = null, string strFunctionName = "PK_");

    }
}