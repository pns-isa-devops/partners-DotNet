using System.Runtime.Serialization;
using System;

namespace Partner.Data {

  [DataContract(Namespace = "http://partner/external/payment/data/",
                Name = "Payment")]
   public class Payment
    {
      [DataMember]
      public int Identifier { get; set; }

      [DataMember]
      public string CountNumberProvider  { get; set; }

      [DataMember]
      public double Amount { get; set; }

      [DataMember]
      public string Date { get; set; }

      [DataMember]
      public int BillId { get; set; }

    }


}
