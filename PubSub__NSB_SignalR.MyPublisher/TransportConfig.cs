using System;
using NServiceBus;
 
namespace PubSub__NSB_SignalR.MyPublisher
{
	public class TransportConfig : INeedInitialization
	{
		public void Init()
		{
			// Tranport: Msmq (Default) - No configuration needed
		}
	}
}
