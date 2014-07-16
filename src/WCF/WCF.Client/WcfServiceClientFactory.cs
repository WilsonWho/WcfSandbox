namespace WCF.Client
{
    public static class WcfServiceClientFactory<TChannel> where TChannel : class 
    {
        public static WcfServiceClient<TChannel> Create(string endpointAddress)
        {
            return new WcfServiceClient<TChannel>(endpointAddress);
        }
    }
}