using DartRail.Overwatch.Loggers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Overwatch
{
    public class OverwatchService
    {
        private IServiceBus _bus;
        private UnsubscribeAction _unsubscribeAction;

        public OverwatchService(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            _unsubscribeAction = _bus.SubscribeConsumer<TicketRequestLogger>();
        }

        public void Stop()
        {
            _unsubscribeAction();
            _bus.Dispose();
        }
    }
}
