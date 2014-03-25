using System;
using NServiceBus;
using PubSub__NSB_SignalR.Contract.Notifications;


namespace PubSub__NSB_SignalR.Notifications
{
    public partial class EventMessageProcessor : IHandleMessages<EventMessage>
    {
		
		public void Handle(EventMessage message)
		{
			this.HandleImplementation(message);
		}

		partial void HandleImplementation(EventMessage message);

		public IBus Bus { get; set; }

    }
}
