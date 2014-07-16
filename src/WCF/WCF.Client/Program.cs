using System;
using System.ServiceModel;
using WCF.Common;
namespace WCF.Client
{
    class Program
    {
        private static WcfServiceClient<ICommunicationChannel> _wcfServiceClient; 

        static void Main(string[] args)
        {
            _wcfServiceClient = WcfServiceClientFactory<ICommunicationChannel>.Create(Constants.RemoteEndpointAddress);

            _wcfServiceClient.Channel.DonateBag(new BagOfGoodies
                {
                    Candy = "Jelly beans",
                    Chocolate = "Hershey's Kisses",
                    IceCream = "Haagen Daas"
                });

            var quotient1 = Divide(10, 5);
            Console.WriteLine("Quotient is {0}", quotient1);

            //var quotient2 = Divide(10, 0);
            //Console.WriteLine("Quotient is {0}", quotient2);

            var quotient3 = SafeDivide(10, 0);
            Console.WriteLine("Quotient is {0}", quotient3);

            Console.ReadLine();
        }

        private static decimal Divide(decimal val1, decimal val2)
        {
            try
            {
                return _wcfServiceClient.Channel.Divide(val1, val2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return -1;
        }

        private static decimal SafeDivide(decimal val1, decimal val2)
        {
            try
            {
                return _wcfServiceClient.Channel.SafeDivide(val1, val2);
            }
            catch (FaultException<CalculatorFault> ex)
            {
                Console.WriteLine(ex.Detail.Message);
            }

            return -1;
        }
    }
}
