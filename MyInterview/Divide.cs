using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MyInterview
{
    class MathOperator
    {
        static int SpecialDivide(int dividen, int divisor, out int residual)
        {
            int originalDivisor = divisor;

            if (divisor == 0)
            {
                throw new Exception();
            }

            // Raise divisor to be equal or lastest smaller than dividen
            while ((divisor << 1) <= dividen)
            {
                divisor = divisor << 1;
            }

            int result = 0;

            // Keypoint: Only need to control the divisor getting smaller and stop when it equals to original.
            while (divisor >= originalDivisor)
            {
                // Keypoint shift first before add result value so that you don't need to deal with result after loop
                // move it right to avoid extra moving.
                result = result << 1;
                if (divisor <= dividen)
                {
                    dividen -= divisor;
                    result += 1;
                }

                divisor = divisor >> 1;
            }

            residual = dividen;

            return result;
        }

        public static void UnitTest()
        {
            int dividen = 523;
            int divisor = 32;

            int residual = 0;
            int result = SpecialDivide(dividen, divisor, out residual);
            int expectedResult = dividen / divisor;
            int expectedResidual = dividen % divisor;

            Debug.Assert(residual == expectedResidual);
            Debug.Assert(result == expectedResult);
        }
    }
}
