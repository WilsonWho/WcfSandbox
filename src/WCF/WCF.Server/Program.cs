using System;
using WCF.Common;

namespace WCF.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new WcfService<CommunicationChannel, ICommunicationChannel>(Constants.RemoteEndpointAddress))
            {
                server.Opened += (sender, eventArgs) => Console.WriteLine("Server open for business!");
                server.Start();

                Console.WriteLine("Service is available. " + "Press <ENTER> to exit");
                Console.ReadLine();

                server.Stop();
            }
        }
    }
}
