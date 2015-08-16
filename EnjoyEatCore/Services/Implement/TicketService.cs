using EnjoyEatCore.Dao.Interface;
using EnjoyEatCore.Services.Interface;
using EnjoyEatCore.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyEatCore.Services.Implement
{
    public partial class TicketService : ITicketService
    {
        public ITicketDao TicketDao { get; set; }

        public Ticket AddTicket(Ticket ticket)
        {
            TicketDao.AddTicket(ticket);
            return GetTicketByName(ticket.Name);
        }

        public void UpdateTicket(Ticket ticket)
        {
            TicketDao.UpdateTicket(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            ticket = TicketDao.GetTicketByName(ticket.Name);

            if (ticket != null)
            {
                TicketDao.DeleteTicket(ticket);
            }
        }
         
        public Ticket GetTicketByName(string phone)
        {
            return TicketDao.GetTicketByName(phone);
        }

        public Ticket GetTicketById(string id)
        {
            return TicketDao.GetTicketById(id);
        }
    }
}
