using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class SlowCashier: Cashier
    {
        public override void Consume(Messages.NewTicketRequestMessage msg)
        {
            Thread.Sleep(4000);
            base.Consume(msg);
        }
    }
}
