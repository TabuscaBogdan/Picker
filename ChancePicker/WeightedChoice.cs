using System;
using System.Collections.Generic;
using System.Text;

namespace ChancePicker
{
    public class WeightedChoice : Choice
    {
        public double Probability;
        public double CumulativeProbability;
    }
}
