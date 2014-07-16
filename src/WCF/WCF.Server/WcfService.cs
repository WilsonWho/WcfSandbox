using System;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Server
{
    internal class WcfService<TServiceType, TServiceInterface> : IWcfService where TServiceType : class
    {
        public event EventHandler Opened;
        private bool _isListening;
        private bool _isDisposed;
        private readonly object _syncObject = new object();

        private ServiceHost _serviceHost;

        internal WcfService(string remoteAddress)
        {
            if (string.IsNullOrEmpty(remoteAddress))
                throw new ArgumentNullException("remoteAddress");

            _isListening = false;
            _isDisposed = false;

            _serviceHost = new ServiceHost(typeof (TServiceType),
                                           new[]
                                               {
                                                   new Uri(Constants.LocalHostNamedPipeUrl)
                                               });
            _serviceHost.AddServiceEndpoint(typeof (TServiceInterface),
                                            new NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport), 
                                            remoteAddress);
            _serviceHost.Opened += ServiceHostOnOpened;
        }

        public void Start()
        {
            if (_isDisposed)
                throw new InvalidOperationException("Service host has already been disposed");

            if (!_isListening)
            {
                lock (_syncObject)
                {
                    if(!_isListening)
                    {
                        _serviceHost.Open();
                        _isListening = true;
                    }
                }
            }
        }

        public void Stop()
        {
            if (_isDisposed)
                throw new InvalidOperationException("Service host has already been disposed");

            if (_isListening)
            {
                lock (_syncObject)
                {
                    if (_isListening)
                    {
                        _serviceHost.Close();
                        _isListening = false;
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_serviceHost != null)
            {
                if (_isListening)
                    _serviceHost.Close();

                _serviceHost.Opened -= ServiceHostOnOpened;
            }

            _serviceHost = null;
            _isDisposed = true;
        }

        public void ServiceHostOnOpened(object sender, EventArgs e)
        {
            EventHandler handler = Opened;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}