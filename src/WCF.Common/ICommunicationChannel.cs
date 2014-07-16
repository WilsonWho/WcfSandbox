using System.ServiceModel;

namespace WCF.Common
{
    [ServiceContract(Name = "CommunicationChannel")]
    public interface ICommunicationChannel
    {
        [OperationContract]
        [FaultContract(typeof(CalculatorFault))]
        void DonateBag(BagOfGoodies bagOfGoodies);

        [OperationContract]
        [FaultContract(typeof(CalculatorFault))]
        decimal Divide(decimal val1, decimal val2);

        [OperationContract]
        [FaultContract(typeof(CalculatorFault))]
        decimal SafeDivide(decimal numerator, decimal denominator);
    }
}