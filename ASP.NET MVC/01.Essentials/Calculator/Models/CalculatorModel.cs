using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace Calculator.Models
{
    public class CalculatorModel
    {
        public BigInteger Quantity { get; set; }

        public Dictionary<string, BigInteger> Types { get; set; }

        public Dictionary<string, decimal> KiloSize { get; set; }

        public CalculatorModel()
        {
            this.Types = new Dictionary<string, BigInteger>();
            this.KiloSize = new Dictionary<string, decimal>();
            this.Quantity = 1;
        }

        public static CalculatorModel Create()
        {
            CalculatorModel calculator = new CalculatorModel();

            calculator.Types.Add("bit - b", 1);
            calculator.Types.Add("Byte - B", 8);
            calculator.Types.Add("kilobit - Kb", 1024);
            calculator.Types.Add("Kilobyte - KB", 8192);
            calculator.Types.Add("Megabit - Mb", 1048576);
            calculator.Types.Add("Megabyte - MB", 8388608);
            calculator.Types.Add("Gigabit - Gb", 1073741824);
            //calculator.Types.Add("Gigabyte - GB", 8589934592);
            //calculator.Types.Add("Terabit - Tb", 1099511627776);
            //calculator.Types.Add("Terabyte - TB", 8796093022208);
            //calculator.Types.Add("Petabit - Pb", 1125899906842624);
            //calculator.Types.Add("Petabyte - PB", 9007199254740992);

            // Dictionary "1024" - 1.024 
            calculator.KiloSize.Add("1024", 1.024m);
            calculator.KiloSize.Add("1000", 1m);

            return calculator;
        }
    }
}