using System;

namespace ChancePicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var picker = new WeightedPicker();
            var ch1 = new Choice {Name = "BigSpender", Points = 10};
            var ch2 = new Choice {Name = "SmallFry", Points = 1};
            var ch3 = new Choice {Name = "Investor1", Points = 2};
            var ch4 = new Choice {Name = "Investor2", Points = 3};
            var ch5 = new Choice {Name = "RiskTaker", Points = 2};
            var ch6 = new Choice {Name = "SmallEnterprize", Points = 2};

            picker.AddChoice(ch1);
            picker.AddChoice(ch2);
            picker.AddChoice(ch3);
            picker.AddChoice(ch4);
            picker.AddChoice(ch5);
            picker.AddChoice(ch6);

            picker.ShowStatus();
        }
    }
}
