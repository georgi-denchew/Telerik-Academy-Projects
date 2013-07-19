using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace _05.Workdays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.Write("Enter date(YYYY/MM/DD): ");
            string[] endStr = Console.ReadLine().Split('/');
            int day = int.Parse(endStr[2]);
            int month = int.Parse(endStr[1]);
            int year = int.Parse(endStr[0]);
            DateTime today = DateTime.Today;

            DateTime end = new DateTime(year, month, day);
            int daysCount = Math.Abs((end - today).Days);

            if (today > end)
            {
                today = end;
                end = DateTime.Today;
            }

            DateTime[] holidays = { new DateTime(2013, 3, 3),
                                    new DateTime(2013, 5, 24),
                                    new DateTime(2013, 9, 22),
                                    new DateTime(2013, 11, 1),
                                    new DateTime(2013, 12, 25),
                                    new DateTime(2013, 12, 26),
                                    new DateTime(2013, 12, 31),
                                  };

            Console.WriteLine("Number of all days:{0} ", daysCount);
            int workdayCount = 0;
            bool isHoliday = false;

            for (int i = 0; i < daysCount; i++)
            {
                today = today.AddDays(1);

                if (today.DayOfWeek != DayOfWeek.Sunday && today.DayOfWeek != DayOfWeek.Saturday)
                {
                    for (int j = 0; j < holidays.Length; j++)
                    {
                        if (today == holidays[j])
                        {
                            isHoliday = true;
                            break;
                        }
                    }

                    if (isHoliday == false)
                    {
                        workdayCount++;
                    }
                }

            }

            Console.WriteLine("Number of workdays (today excluded):{0} " ,workdayCount);
        }
    }
}
