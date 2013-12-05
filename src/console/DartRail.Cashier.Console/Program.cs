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
                sbc.SetConcurrentConsumerLimit(1); //for demo puproses
            });

            HostFactory.Run(x =>                                 
            {
                x.Service<CashierService>(s =>
                {
                    s.ConstructUsing(name => new CashierService(_bus));
                    s.WhenStarted(tc => tc.Start<SlowCashier>());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Cashier Service");
                x.SetDisplayName("Dart - Cashier Service");
                x.SetServiceName("Dart_Cashier");
            });      



        }
    }
}
