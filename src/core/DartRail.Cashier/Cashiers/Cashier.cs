using DartRail.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class Cashier : Consumes<NewTicketRequestMessage>.All
    {
        public Cashier()
        {

        }
        
        public virtual void Consume(NewTicketRequestMessage msg)
        {
            Console.WriteLine(string.Format("Here's your tick {0}", msg.Name));
        }
    }
}
