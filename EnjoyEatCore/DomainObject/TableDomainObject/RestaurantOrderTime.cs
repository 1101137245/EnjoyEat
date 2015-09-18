namespace EnjoyEatCore.DomainObject.TableDomainObject
{
    public class RestaurantOrderTime
    {
        /// <summary>                                  
        /// 餐廳點餐時間編號                                  
        /// </summary>                          
        public string RestaurantOrderTime_ID { get; set; }


        /// <summary>                                  
        /// 時間                                  
        /// </summary>                          
        public string RestaurantOrderTime_Time { get; set; }


        /// <summary>                                  
        /// 是否可點餐                                  
        /// </summary>                          
        public string RestaurantOrderTime_Open { get; set; }


        /// <summary>                                  
        /// 餐廳編號                                  
        /// </summary>                          
        public string Restaurant_ID { get; set; }     



    }
}