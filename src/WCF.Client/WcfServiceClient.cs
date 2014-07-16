using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using WCF.Common;

namespace WCF.Client
{
    public class WcfServiceClient<TChannel> where TChannel : class 
    {
        private readonly WcfServiceClientInternal _wcfServiceClientInternal;

        public WcfServiceClient(string endpointAddress)
        {
            if (string.IsNullOrWhiteSpace(endpointAddress))
                throw new ArgumentNullException("endpointAddress");

            var baseUri = new Uri(Constants.LocalHostNamedPipeUrl);
            var endpoint = new EndpointAddress(new Uri(baseUri, endpointAddress));

            _wcfServiceClientInternal = new WcfServiceClientInternal(new NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport), endpoint);
        }

        public TChannel Channel
        {
            get { return _wcfServiceClientInternal.CommunicationChannel; }
        }

        private class WcfServiceClientInternal : ClientBase<TChannel>
        {
            public WcfServiceClientInternal(Binding binding, EndpointAddress endpointAddress)
                : base(binding, endpointAddress)
            {

            }

            public TChannel CommunicationChannel
            {
                get { return Channel; }
            }
        }
    } 
}