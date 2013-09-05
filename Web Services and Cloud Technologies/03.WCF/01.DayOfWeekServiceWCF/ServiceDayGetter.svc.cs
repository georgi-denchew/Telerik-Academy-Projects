using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Globalization;


namespace _01.DayOfWeekServiceWCF
{
    public class ServiceDayGetter : IServiceDayGetter
    {
        public string GetDay(DateTime date)
        {
            return string.Format("{0}", date.ToString("dddd", new CultureInfo("bg-BG")));
        }
    }
}
