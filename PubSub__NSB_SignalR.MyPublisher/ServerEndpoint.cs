using System;
using NServiceBus;
using PubSub__NSB_SignalR.Contract.Notifications;

namespace PubSub__NSB_SignalR.MyPublisher
{
    class ServerEndpoint : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("This will publish IEvent, EventMessage, and AnotherEventMessage alternately.");
            Console.WriteLine("Press 'Enter' to publish a timer message.To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {     
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += timer_Elapsed;
                timer.Interval = 3000;
                timer.Enabled = true;
               
                EventMessage eventMessage = new EventMessage();

                eventMessage.EventId = Guid.NewGuid();
                eventMessage.Time = DateTime.Now;
                eventMessage.Duration = TimeSpan.FromSeconds(99999D);

                Bus.Publish(eventMessage);

                Console.WriteLine("Published event with Id {0} {1}", eventMessage.EventId, eventMessage.Time.ToString());
                Console.WriteLine("==========================================================================");
            }
        }

        public void Stop()
        {
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EventMessage eventMessage = new EventMessage();
            eventMessage.EventId = Guid.NewGuid();
            eventMessage.Time = DateTime.Now;
            eventMessage.Duration = TimeSpan.FromSeconds(99999D);
            Bus.Publish(eventMessage);
            Console.WriteLine("Published event with Id {0} {1}", eventMessage.EventId, eventMessage.Time.ToString());
            Console.WriteLine("==========================================================================");
        }
    }
}
