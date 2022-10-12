using System;
using System.Collections.Generic;

namespace eventbus
{
    public interface IEvent
    {
    }

    public interface ISubscriber<T> where T : IEvent
    {
        void OnEvent(T @event);
    }
    
    public class EventBus<T> where T : IEvent
    {
        private readonly HashSet<ISubscriber<T>> _subscribers = new HashSet<ISubscriber<T>>();

        public void Subscribe(ISubscriber<T> subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void UnSubscribe(ISubscriber<T> subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        
        public void Post(T @event)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.OnEvent(@event);
            }
            
        }
        
    }
}