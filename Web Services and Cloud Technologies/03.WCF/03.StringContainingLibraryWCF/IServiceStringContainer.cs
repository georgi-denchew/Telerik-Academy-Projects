using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringContainingLibraryWCF
{
    [ServiceContract]
    public interface IServiceStringContainer
    {
        [OperationContract]
        string PrintContainCount(string part, string container);
    }
}