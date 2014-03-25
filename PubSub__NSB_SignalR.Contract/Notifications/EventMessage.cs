using System;
using NServiceBus;

namespace PubSub__NSB_SignalR.Contract.Notifications
{
    public class EventMessage
    {
        public Guid EventId { get; set; }
        public DateTime? Time { get; set; }
        public TimeSpan Duration { get; set; }
    } 
}
