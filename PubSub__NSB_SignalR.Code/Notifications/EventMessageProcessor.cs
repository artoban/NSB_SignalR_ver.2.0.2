using System;
using NServiceBus;
using PubSub__NSB_SignalR.Contract.Notifications;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using PubSub__NSB_SignalR.SignalRSubscriber1;


namespace PubSub__NSB_SignalR.Notifications
{
    public partial class EventMessageProcessor
    {
		
        partial void HandleImplementation(EventMessage message)
        {
            // Implement your handler logic here.
            System.Diagnostics.Trace.TraceInformation("Notifications received: {0}", message.GetType().Name);

            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            hubContext.Clients.All.send(message.Time.ToString());
        }

    }
}
