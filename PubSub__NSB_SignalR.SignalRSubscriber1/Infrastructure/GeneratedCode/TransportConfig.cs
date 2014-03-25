using System;
using NServiceBus;
 
namespace PubSub__NSB_SignalR.SignalRSubscriber1
{
	public class TransportConfig : INeedInitialization
	{
		public void Init()
		{
			// Tranport: Msmq (Default) - No configuration needed
  		}
	}
}
