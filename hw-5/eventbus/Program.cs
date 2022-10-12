using System;

namespace eventbus
{
    internal class Program
    {
        public class EventA : IEvent
        {
            public readonly string Name;
            public readonly string From;

            public EventA(string name, string from)
            {
                Name = name;
                From = from;
            }
        }

        public class EventB : IEvent
        {
            public readonly int X;
            public readonly int Y;

            public EventB(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        
        public class SubscriberA : ISubscriber<EventA>
        {
            public readonly string Name;

            public SubscriberA(string name)
            {
                Name = name;
            }

            public void OnEvent(EventA @event)
            {
                Console.Out.WriteLine($"Subscriber {Name} received event {@event.Name} from {@event.From}");
            }
        }

        public class SubscriberB : ISubscriber<EventB>
        {
            public void OnEvent(EventB @event)
            {
                Console.Out.WriteLine($"SubscriberB received EventB with data ({@event.X}, {@event.Y})");
            }
        }

        public static void Main(string[] args)
        {
            var eventBusA = new EventBus<EventA>();

            var subscriberA1 = new SubscriberA("Subscriber_A_#1");
            var subscriberA2 = new SubscriberA("Subscriber_A_#2");

            eventBusA.Subscribe(subscriberA1);
            eventBusA.Subscribe(subscriberA2);
            
            eventBusA.Post(new EventA("<EventA: 0>", "Main_#1"));

            eventBusA.UnSubscribe(subscriberA1);
                
            eventBusA.Post(new EventA("<EventA: 0>", "Main_#2"));


            var eventBusB = new EventBus<EventB>();

            var subscriberB = new SubscriberB();

            eventBusB.Subscribe(subscriberB);

            eventBusB.Post(new EventB(4, 2));
        }
    }
}