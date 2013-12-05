using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class AdvancedCashierService
    {
        private IServiceBus _bus;
        private List<UnsubscribeAction> _unsubscribeActions;

        public AdvancedCashierService(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {            
            Console.WriteLine("[Cashier Service] Now accepting ticket requests!");
        }

        public void Stop()
        {
            foreach (var unsubscribeAction in _unsubscribeActions)
            {
                unsubscribeAction();
            }

            if (_bus != null)
            {
                _bus.Dispose();
                _bus = null;
            }

            Console.WriteLine("[Cashier Service] No longer accepting ticket requests.");
        }

    }
}
