using System;
using System.Collections.Generic;
using System.Text;

namespace ChancePicker
{
    public static class PrecentCalculator
    {
        public static double GetPrecentage(int unit, int total)
        {
            return ((double)(100 * unit)) / total;
        }
    }
}
