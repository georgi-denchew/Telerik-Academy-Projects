using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _10.AddRemoveClearMethods
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
    public class Battery
    {
        private BatteryType battModel;
        private int? hoursIdle;
        private int? hoursTalk;

        public Battery(BatteryType battModel) : this(battModel, null, null)
        {
        }

        public Battery(BatteryType battModel, int? hoursIdle, int? hoursTalk)
        {
            this.battModel = battModel;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public BatteryType BattModel
        {
            get { return this.battModel; }
            set { this.battModel = value; }
        }

        public int? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value >= 0 || value == null)
                {
                    this.hoursIdle = value;
                }
                else
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid idle hours number.");
                        Environment.Exit(0);
                    }
                }
            }
        }

        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value >= 0 || value == null)
                {
                    this.hoursTalk = value;
                }
                else
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid talk hours number.");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
