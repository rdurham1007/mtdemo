using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class CashierService
    {
        private IServiceBus _bus;
        private UnsubscribeAction _unsubscribeAction;

        public CashierService(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            _unsubscribeAction = _bus.SubscribeConsumer<SimpleCashier>();
            Console.WriteLine("Cashier reporting for duty!");
        }

        public void Stop()
        {
            _unsubscribeAction();
            _bus.Dispose();
            Console.WriteLine("Cashier leaving for the day!");
        }
    }
}
