using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventLibrary.Services;

namespace EventLibrary
{
    public class EventHub : IEventHub
    {
        readonly List<object> services = new();

        public EventHub() => 
            services = new List<object>();
        

        public void ListenToEvent<T>(string name, Func<T, ValueTask> handler) => 
            GetEventService<T>().ListenToEvent(name, handler);

        public async ValueTask RaiseEventAsync<T>(string name, T data) =>
            await GetEventService<T>().RaiseEventAsync(name, data);

        IEventService<T> GetEventService<T>() =>
            services.FirstOrDefault(s => s.GetType().GenericTypeArguments[0] == typeof(T)) as IEventService<T>
                    ??
                CreateEventService<T>();

        IEventService<T> CreateEventService<T>()
        {
            var service = new EventService<T>(new EventBroker<T>());
            services.Add(service);
            return service;
        }
    }
}