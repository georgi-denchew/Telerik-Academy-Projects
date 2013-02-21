using System;
using System.Threading;
using System.Globalization;

namespace _04.ToStringOverride
{
    //Add a method in the GSM class for displaying all information about it. Try to override ToString().

    class Specifications
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Battery battery = new Battery(BatteryType.LiIon, 600, 10);
            Display display = new Display(2, 172385);
            string manifacturer = "Samsung";
            string model = "Galaxy SII";
            decimal? price = 400;
            string owner = "Krali Marko";
            GSM phone = new GSM(manifacturer, model, price, owner, battery, display);
            Console.WriteLine(phone.ToString());
        }
    }
}
