using System;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Server
{
    public class CommunicationChannel : ICommunicationChannel
    {
        public void DonateBag(BagOfGoodies bagOfGoodies)
        {
            Console.WriteLine(bagOfGoodies.Candy);
            Console.WriteLine(bagOfGoodies.Chocolate);
            Console.WriteLine(bagOfGoodies.IceCream);
        }

        public decimal Divide(decimal val1, decimal val2)
        {
            return Decimal.Divide(val1, val2);
        }

        public decimal SafeDivide(decimal numerator, decimal denominator)
        {
            if (denominator == 0)
                throw new FaultException<CalculatorFault>(new CalculatorFault("Cannot divide by zero!", null));

            return Decimal.Divide(numerator, denominator);
            
        }
    }
}