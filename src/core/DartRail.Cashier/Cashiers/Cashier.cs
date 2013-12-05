using DartRail.Messages;
using MassTransit;
using MassTransitDemo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Cashier
{
    public class Cashier : Consumes<NewTicketRequestMessage>.All
    {

        public string Name { get; set; }
        private UnsubscribeAction _unsubscribeAction;

        public Cashier()
        {
            Name = NameGenerator.NewName();
        }
        
        public virtual void Consume(NewTicketRequestMessage msg)
        {
            Console.WriteLine(string.Format("["+ Name + " (Cashier)] Here's your ticket {0}", msg.Name));
        }

        public virtual void Subscribe(IServiceBus bus)
        {
            if (_unsubscribeAction != null)
            {
                _unsubscribeAction();
            }
            
            _unsubscribeAction = bus.SubscribeInstance(this);
        }

        public virtual void Unsubscribe()
        {
            _unsubscribeAction();
        }

    }
}
