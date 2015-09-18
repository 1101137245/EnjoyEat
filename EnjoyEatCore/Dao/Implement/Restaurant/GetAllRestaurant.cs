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
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Dao.Implement.RestaurantDao
{
    public partial class RestaurantDao : BaseDao, IRestaurantDao
    {
        public IList<Restaurant> GetAllRestaurant(Restaurant obj)
        {

            //string command = @"SELECT * FROM Restaurant ";
            StringBuilder command = SqlBuilder.Query(obj);           
            Restaurant obj1 = new Restaurant();
            Restaurant obj2 = new Restaurant();
            obj1.Restaurant_ID = "1";
            obj1.Restaurant_Name = "王品";
            obj2.Restaurant_Name = "王品";
            obj2.Restaurant_Parking = "1";
            string[] abcd={
                         "Restaurant_ID","Restaurant_Name"
                     };
            StringBuilder abc = SqlBuilder.Query(obj1);

            StringBuilder abcde = SqlBuilder.Insert(obj2);
            StringBuilder abcdef = SqlBuilder.Delete(obj2);
            StringBuilder abcdee = SqlBuilder.Update(obj2);

            IDbParameters parameters = CreateDbParameters();
            SetParameters(abc.ToString(), obj1, ref parameters);

            IList<Restaurant> restaurant = base.QueryWithRowMapper<Restaurant>(CommandType.Text, Convert.ToString(command), new GenerateRowMapper<Restaurant>());
            return restaurant;
        }
    }
}
