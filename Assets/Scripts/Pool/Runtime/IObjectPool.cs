using System;

namespace Pool.Runtime
{
    public interface IObjectPool<T> : IDisposable
    {
        T Request();
        void Return(T obj);
    }
}
