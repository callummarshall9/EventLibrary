using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventLibrary
{
    public interface IEventBroker<T>
    {
        public IEnumerable<Func<T, ValueTask>> GetHandlers(string name);
        public void ListenToEvent(string name, Func<T, ValueTask> handler);
    }
}