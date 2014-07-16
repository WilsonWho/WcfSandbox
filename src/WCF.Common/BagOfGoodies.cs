using System.Runtime.Serialization;

namespace WCF.Common
{
    [DataContract]
    public class BagOfGoodies
    {
        [DataMember]
        public string Candy { get; set; }
        
        [DataMember]
        public string Chocolate { get; set; }

        [DataMember]
        public string IceCream { get; set; }
    }
}