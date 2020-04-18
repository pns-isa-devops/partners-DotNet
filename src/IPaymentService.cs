using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;

using Partner.Data;

namespace Partner.Service {

  [ServiceContract]
  public interface IPaymentService
  {

    [OperationContract]
    [WebInvoke( Method = "GET", UriTemplate = "payments/{identifier}",
                ResponseFormat = WebMessageFormat.Json)]
    Payment FindPaymentById(int identifier);

    [OperationContract]
    [WebInvoke( Method = "GET", UriTemplate = "payments",
                ResponseFormat = WebMessageFormat.Json)]
    List<int> GetAllPaymentIds();

}

}
