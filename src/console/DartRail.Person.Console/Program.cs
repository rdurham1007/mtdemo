using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DartRail.Person.Console
{
    class Program
    {
        private static IServiceBus _bus;

        static void Main(string[] args)
        {
            _bus = ServiceBusFactory.New(sbc =>
            {
                sbc.ReceiveFrom("rabbitmq://localhost/person_service");
                sbc.UseRabbitMq();
            });

            HostFactory.Run(x =>
            {
                x.Service<PersonService>(s =>
                {
                    s.ConstructUsing(name => new PersonService(_bus));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Person Service");
                x.SetDisplayName("Dart - Person Service");
                x.SetServiceName("Dart_Person");
            });      
        }
    }
}
