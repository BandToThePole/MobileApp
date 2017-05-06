using System;
using System.Collections.Generic;
using System.Text;

namespace BTTP
{
    public class DCEntry
    {
        public double dist;
        public double cal;

        public DCEntry(double cal, double dist)
        {
            this.dist = dist;
            this.cal = cal;
        }
    }
}
