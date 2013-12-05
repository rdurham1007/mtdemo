using DartRail.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class SimpleCashier: Cashier
    {
        public override void Consume(NewTicketRequestMessage msg)
        {
            base.Consume(msg);
        }
    }
}
