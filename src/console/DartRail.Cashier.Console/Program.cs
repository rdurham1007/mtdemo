using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DartRail.Cashier.Console
{
    class Program
    {
        private static IServiceBus _bus;

        static void Main(string[] args)
        {
            _bus = ServiceBusFactory.New(sbc =>
            {
                sbc.ReceiveFrom("rabbitmq://localhost/cashier_line");
                sbc.UseRabbitMq();
            });

            HostFactory.Run(x =>                                 //1
            {
                x.Service<CashierService>(s =>                        //2
                {
                    s.ConstructUsing(name => new CashierService(_bus));     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("Cashier Service");        //7
                x.SetDisplayName("Dart - Cashier Service");                       //8
                x.SetServiceName("Dart_Cashier");                       //9
            });      



        }
    }
}
