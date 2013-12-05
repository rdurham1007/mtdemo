using DartRail.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Overwatch.Loggers
{
    public class TicketRequestLogger : Consumes<NewTicketRequestMessage>.All
    {
        public void Consume(NewTicketRequestMessage msg)
        {
            Console.WriteLine(string.Format("LOGGER: [{0}] reqeusted a new ticket.", msg.Name));
        }
    }
}
