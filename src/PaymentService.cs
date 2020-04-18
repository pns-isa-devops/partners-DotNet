using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Linq;
using Partner.Data;

namespace Partner.Service {

  // The service is stateful, as it is only a Proof of Concept.
  // Services should be stateless, this is for demonstration purpose only.
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class PaymentService : IPaymentService
  {
    private Dictionary<int, Payment> accounts = new Dictionary<int, Payment>(){
    {1, new Payment() {Identifier= 1, CountNumberProvider="000100", Amount=30.0, Date="15-03-2020", BillId= 3}},
    {2, new Payment() {Identifier=2, CountNumberProvider="000200", Amount=20.0, Date="15-03-2020", BillId= 1}},
    };

    private int counter;

   //Id provider and his account number
   //We suppose that each provider pay with the same bank account that we have already record
    private Dictionary<int, string> providerBankAccount = new Dictionary<int, string>()
   {
    {1, "000100"},
    {2, "000200"},
    {3, "000300"}
    };

    public Payment FindPaymentById(int identifier)
    {
      Console.WriteLine("Consultation du payement de la facture qui a pour ID : "+identifier);
      foreach(KeyValuePair<int, Payment> entry in accounts)
       {
          if(entry.Value.BillId == identifier) {
                     return entry.Value;
          }
        }
         WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
         return null;
    }

    public List<int> GetAllPaymentIds()
    {
      return accounts.Select (d => d.Value.BillId).ToList();
    }


  }
}
