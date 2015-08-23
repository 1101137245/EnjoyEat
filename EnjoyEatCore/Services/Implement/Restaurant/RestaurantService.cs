using EnjoyEatCore.Dao.Interface;
using EnjoyEatCore.Services.Interface;
using EnjoyEatCore.DomainObject.TableDomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Services.Implement.RestaurantService
{
    public partial class RestaurantService:IRestaurantService
    {
        public IRestaurantDao RestaurantDao { get; set; }

        public IList<Restaurant> GetAllRestaurant()
        {
            Restaurant obj = new Restaurant();
            IList<Restaurant> restaurant = RestaurantDao.GetAllRestaurant(obj);
            return restaurant;
        }
    }
}
