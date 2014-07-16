using System;

namespace WCF.Server
{
    public interface IWcfService : IDisposable
    {
        void Start();
        void Stop();
    }
}