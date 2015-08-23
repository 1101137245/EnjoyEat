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
            string[] abcd={
                         "Restaurant_ID","Restaurant_Name"
                     };
            StringBuilder abc = SqlBuilder.Query(obj1, abcd);
            IList<Restaurant> restaurant = base.QueryWithRowMapper<Restaurant>(CommandType.Text, Convert.ToString(command), new GenerateRowMapper<Restaurant>());
            return restaurant;
        }
    }
}
