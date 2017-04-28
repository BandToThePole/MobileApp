using System;
using System.Collections.Generic;
using System.Text;

namespace BTTP
{
    public class Entry
    {
        public DateTime date;
        public double value;

        public Entry(double value, DateTime date)
        {
            this.value = value;
            this.date = date;
        }
    }
}
