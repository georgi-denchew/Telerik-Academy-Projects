using System;

namespace _04.ToStringOverride
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
            set { this.hoursIdle = value; }
        }

        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }
    }
}
