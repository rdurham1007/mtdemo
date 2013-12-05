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

            HostFactory.Run(x =>                                 //1
            {
                x.Service<PersonService>(s =>                        //2
                {
                    s.ConstructUsing(name => new PersonService(_bus));     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("Person Service");        //7
                x.SetDisplayName("Dart - Person Service");                       //8
                x.SetServiceName("Dart_Person");                       //9
            });      
        }
    }
}
