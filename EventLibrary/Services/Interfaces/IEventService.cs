using System;
using System.Threading.Tasks;

namespace EventLibrary.Services
{
    public interface IEventService<T>
    {
        void ListenToEvent(string name, Func<T, ValueTask> handler);
        ValueTask RaiseEventAsync(string name, T data);
    }
}