using System;
using NServiceBus;


namespace PubSub__NSB_SignalR.Notifications
{
    public partial class EventMessageSender 
    {
		

		public IBus Bus { get; set; }

    }
}
