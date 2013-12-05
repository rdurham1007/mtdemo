using DartRail.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class SimpleCashier: Consumes<NewTicketRequest>.All
    {
        public void Consume(NewTicketRequest msg)
        {
            Console.WriteLine(string.Format("Here's your ticket {0}", msg.Name));
        }
    }
}
