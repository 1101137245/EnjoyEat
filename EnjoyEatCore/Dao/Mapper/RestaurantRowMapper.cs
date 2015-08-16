using EnjoyEatCore.DomainObject.TableDomainObject;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Dao.Mapper
{
    class RestaurantRowMapper : IRowMapper<Restaurant>
    {
        public Restaurant MapRow(IDataReader dataReader, int rowNum)
        {
            Restaurant target = new Restaurant();

            target.Restaurant_ID = dataReader.GetString(dataReader.GetOrdinal("Restaurant_ID"));
            target.Restaurant_Name = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Name"));
            target.Restaurant_BranchName = dataReader.GetString(dataReader.GetOrdinal("Restaurant_BranchName"));
            target.Restaurant_Addresszip = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Addresszip"));
            target.Restaurant_Address = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Address"));
            target.Restaurant_Telephonearea = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Telephonearea"));
            target.Restaurant_Telephone = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Telephone"));
            target.Restaurant_Officialwebsite = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Officialwebsite"));
            target.Restaurant_Capacity = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Capacity"));
            target.Restaurant_Parking = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Parking"));
            target.Restaurant_Creditcard = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Creditcard"));
            target.Restaurant_Accessible = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Accessible"));
            target.Restaurant_Wifi = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Wifi"));
            target.Restaurant_Costmax = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Costmax"));
            target.Restaurant_Costmin = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Costmin"));
            target.Restaurant_Costavg = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Costavg"));
            target.Restaurant_Mincharge = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Mincharge"));
            target.Restaurant_Summary = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Summary"));
            target.Restaurant_Trafficinformation = dataReader.GetString(dataReader.GetOrdinal("Restaurant_Trafficinformation"));
            target.Company_ID = dataReader.GetString(dataReader.GetOrdinal("Company_ID"));
            target.Region_ID = dataReader.GetString(dataReader.GetOrdinal("Region_ID"));

            return target;
        }
    }
}
