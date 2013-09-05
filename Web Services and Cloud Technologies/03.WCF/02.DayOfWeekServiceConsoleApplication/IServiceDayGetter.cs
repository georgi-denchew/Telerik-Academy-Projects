using System;
using System.ServiceModel;

namespace _01.DayOfWeekServiceWCF
{
    [ServiceContract]
    public interface IServiceDayGetter
    {

        [OperationContract]
        string GetDay(DateTime date);
    }    
}
