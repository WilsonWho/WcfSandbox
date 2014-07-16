using System;
using System.Runtime.Serialization;

namespace WCF.Common
{
    [DataContract]
    public class CalculatorFault
    {
        [DataMember]
        public string Message { get; private set; }
        
        [DataMember]
        public Exception InnerException { get; private set; }

        public CalculatorFault(string message, Exception innerException)
        {
            Message = message;
            InnerException = innerException;
        } 
    }
}