using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _05.PropertyEncapsulation
{
    //Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
    //Ensure all fields hold correct data at any given time.

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
