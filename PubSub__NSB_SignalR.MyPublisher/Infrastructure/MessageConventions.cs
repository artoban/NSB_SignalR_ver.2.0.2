using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace PubSub__NSB_SignalR.MyPublisher
{
    public class MessageConventions : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance
            .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("PubSub__NSB_SignalR.InternalMessages"))
            .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("PubSub__NSB_SignalR.Contract"));
        }
    }
}

