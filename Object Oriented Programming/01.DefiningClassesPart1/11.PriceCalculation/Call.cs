using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _11.PriceCalculation
{
    public class Call
    {
        private DateTime datetime;
        private string number; // I initialize a string, because a phone number could be of a type 1-800-CALL
        private long duration;

        public Call(DateTime datetime, string number, long duration)
        {
            this.datetime = datetime;
            this.number = number;
            this.duration = duration;
        }

        public DateTime Datetime
        {
            get { return this.datetime; }
            set { this.datetime = value; }
        }

        public string Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public long Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
    }
}
