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
        public IList<Restaurant> GetAllRestaurant()
        {
            string command = @"SELECT * FROM Restaurant ";
            IList<Restaurant> restaurant = base.QueryWithRowMapper<Restaurant>(CommandType.Text, Convert.ToString(command), new GenerateRowMapper<Restaurant>());
            return restaurant;
        }
    }
}
