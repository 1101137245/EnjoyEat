using EnjoyEatCore.DomainObject.TableDomainObject;
using EnjoyEatCore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace EnjoyEatWebApp.Controllers
{
    public class RestaurantController : ApiController
    {
        public IRestaurantService RestaurantService { get; set; }

        [HttpGet]
        public IList<Restaurant> GetAllRestaurant()
        {
            return RestaurantService.GetAllRestaurant();
        }
    }
}