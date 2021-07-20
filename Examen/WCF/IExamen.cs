using Examen_Quarks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WCF
{
    [ServiceContract]
    public interface IExamen
    {
        [OperationContract]
        List<DomicilioConsulta> consultarUnCP(int DCP);
    }
}