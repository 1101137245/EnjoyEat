﻿using EnjoyEatCore.DomainObject;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Dao.Mapper
{
    class TicketRowMapper : IRowMapper<Ticket>
    {
        public Ticket MapRow(IDataReader dataReader, int rowNum)
        {
            Ticket target = new Ticket();

            target.Id = dataReader.GetString(dataReader.GetOrdinal("Ticket_ID"));
            target.Name = dataReader.GetString(dataReader.GetOrdinal("Ticket_Name"));
            target.Quantity = dataReader.GetString(dataReader.GetOrdinal("Ticket_Quantity"));
            target.Date = dataReader.GetString(dataReader.GetOrdinal("Ticket_Date"));
            target.Time = dataReader.GetString(dataReader.GetOrdinal("Ticket_Time"));
            target.Aboard = dataReader.GetString(dataReader.GetOrdinal("Ticket_Aboard"));
            target.Getoff = dataReader.GetString(dataReader.GetOrdinal("Ticket_Getoff"));
            target.Number = dataReader.GetString(dataReader.GetOrdinal("Ticket_Number"));
            target.Phone = dataReader.GetString(dataReader.GetOrdinal("Ticket_Phone"));
            target.Price = dataReader.GetString(dataReader.GetOrdinal("Ticket_Price"));

            return target;
        }
    }
}
