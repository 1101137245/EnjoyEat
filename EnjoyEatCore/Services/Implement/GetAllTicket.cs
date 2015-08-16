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
        public IList<Ticket> GetAllTicket()
        {
            IList<Ticket> Ticket = TicketDao.GetAllTicket();
            Ticket[1].Aboard = "0";
            return Ticket;
        }


    }
}
