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
        private IRestaurantDao RestaurantDao { get; set; }

        private ISingleDao SingleDao { get; set; }

        public IList<Restaurant> GetAllRestaurant()
        {
            Restaurant obj = new Restaurant();
            Restaurant obj2 = new Restaurant();
            obj2.Restaurant_ID = "1";
            string[] abcd ={
                         "Restaurant_ID","Restaurant_Name"
                     };
            IList<Restaurant> Resta2 = SingleDao.ReadData(obj2, abcd);
            IList<Restaurant> restaurant = RestaurantDao.GetAllRestaurant(obj);
            return restaurant;
        }
    }
}
