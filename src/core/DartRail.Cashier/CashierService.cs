﻿using MassTransit;
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
        private Cashier _cashier;

        public CashierService(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Start<T>() where T : Cashier, new()
        {
            _cashier = new T();
            _cashier.Subscribe(_bus);
            Console.WriteLine("[Cashier Service] Now accepting ticket requests!");
        }

        public void Stop()
        {
            _cashier.Unsubscribe();
            _bus.Dispose();
            Console.WriteLine("[Cashier Service] No longer accepting ticket requests.");
        }
    }
}
