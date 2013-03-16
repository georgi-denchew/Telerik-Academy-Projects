using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InvalidRangeException
{
    class SampleApplication
    {
        static void InRange(object obj)
        {
            if (obj is Int32)
            {
                try
                {
                    if ((int)obj < 1 || (int)obj > 100)
                    {
                        throw new InvalidRangeException<int>("Integer out of range", new Exception(), 1, 100);
                    }
                }
                catch (InvalidRangeException<int> ex)
                {
                    throw new InvalidRangeException<int>("Integer is out of the range [1, 100]", ex, 1, 100);
                }
            }

            if (obj is DateTime)
            {
                try
                {
                    if ((DateTime)obj < new DateTime(1980, 1, 1) || (DateTime)obj > new DateTime(2013, 12, 31))
                    {
                        throw new InvalidRangeException<DateTime>("Date out of range", new Exception(), new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                    }
                }
                catch (InvalidRangeException<DateTime> ex)
                {

                    throw new InvalidRangeException<DateTime>("Date out of range", new Exception(), new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
            }
        }


        static void Main(string[] args)
        {
            int i = 0;
            DateTime date = new DateTime(1979, 1, 1);
            //InRange(i);
            InRange(date);
        }
    }
}
