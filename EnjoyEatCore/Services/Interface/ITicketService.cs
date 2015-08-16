﻿using EnjoyEatCore.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Services.Interface
{
    public interface ITicketService
    {
        Ticket AddTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        void DeleteTicket(Ticket ticket);

        IList<Ticket> GetAllTicket();

        Ticket GetTicketByName(string phone);

        Ticket GetTicketById(string id);
    }
}
