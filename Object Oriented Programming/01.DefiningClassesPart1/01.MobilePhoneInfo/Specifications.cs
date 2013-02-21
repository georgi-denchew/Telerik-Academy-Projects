using System;
using System.Threading;
using System.Globalization;

namespace _01.MobilePhoneInfo
{
    //Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery 
    //characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). 
    //Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

    class Specifications
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            GSM phone = new GSM();
            Console.WriteLine("Phone specifications:");
            Console.WriteLine("Phone model: {0}", phone.Model);
            Console.WriteLine("Phone manifacturer: {0}", phone.Manifacturer);
            Console.WriteLine("Phone price: {0:C}", phone.Price);
            Console.WriteLine("Phone owner: {0}", phone.Owner);
            Console.WriteLine();
            Console.WriteLine("Battery specifications:");
            Console.WriteLine("Battery model: {0}", phone.battery.Model);
            Console.WriteLine("Hours idle: {0}",phone.battery.HoursIdle);
            Console.WriteLine("Hours talk: {0}", phone.battery.HoursTalk);
            Console.WriteLine();
            Console.WriteLine("Display specifications:");
            Console.WriteLine("Display size: {0}", phone.display.Size);
            Console.WriteLine("Number of colors: {0}", phone.display.Colors);

        }
    }
}
