using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Sqrt
    {
        static double Compute(double a, double precision)
        {
            double x0 = precision + a;
            double x = a;

            while(Math.Abs(x - x0) >= precision)
            {
                x0 = x;
                x = (x0 + a / x0) / 2;
            }
            
            return x;
        }

        public static void UnitTest()
        {
           Console.Write("Expected: {0}, Actual: {1}", Math.Sqrt(0.5), Compute(0.5, 0.0001));
           Console.Write("Expected: {0}, Actual: {1}", Math.Sqrt(5), Compute(5, 0.0001));
           Console.Write("Expected: {0}, Actual: {1}", Math.Sqrt(0.00002), Compute(0.00002, 0.0001));
        }
    }
}
