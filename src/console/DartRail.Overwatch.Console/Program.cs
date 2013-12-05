using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DartRail.Overwatch.Console
{
    class Program
    {
        private static IServiceBus _bus;

        static void Main(string[] args)
        {
            _bus = ServiceBusFactory.New(sbc =>
            {
                sbc.ReceiveFrom("rabbitmq://localhost/overwatch");
                sbc.UseRabbitMq();
                //sbc.SetConcurrentConsumerLimit(1); //for demo puproses
            });

            HostFactory.Run(x =>
            {
                x.Service<OverwatchService>(s =>
                {
                    s.ConstructUsing(name => new OverwatchService(_bus));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Overwatch Service");
                x.SetDisplayName("Dart - Overwatch Service");
                x.SetServiceName("Dart_Overwatch");
            });     
        }
    }
}
