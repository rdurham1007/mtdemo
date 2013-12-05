using DartRail.Messages;
using Magnum;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DartRail.Person
{
    public class PersonService
    {
        private IServiceBus _bus;
        private CancellationTokenSource _tokenSource;

        public PersonService(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken ct = _tokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                var nextPerson = DateTime.Now;

                while(true)
                {

                    if(nextPerson < DateTime.Now)
                    {
                        nextPerson = DateTime.Now.AddSeconds(2);
                        var name = NameGenerator.NewName();

                        _bus.Publish(new NewTicketRequestMessage
                        {
                            CorrelationId = CombGuid.Generate(),
                            Name = name
                        });

                        Console.WriteLine(name + ": I'd like a ticket please.");
                    }

                    if (ct.IsCancellationRequested)
                    {
                        // another thread decided to cancel
                        Console.WriteLine("Stopping Person Service");
                        break;
                    }
                }
            }, ct);
        }

        public void Stop()
        {
            _tokenSource.Cancel();
        }
    }
}
