using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRail.Messages
{
    [Serializable]
    public class NewTicketRequest: CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public string Name { get; set; }
    }
}
