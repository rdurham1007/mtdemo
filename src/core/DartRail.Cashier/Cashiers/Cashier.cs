using DartRail.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class Cashier : Consumes<NewTicketRequest>.All
    {
        public Cashier()
        {

        }
        
        public virtual void Consume(NewTicketRequest msg)
        {
            Console.WriteLine(string.Format("Here's your tick {0}", msg.Name));
        }
    }
}
