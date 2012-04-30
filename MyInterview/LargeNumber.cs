using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class LargeNumber
    {
        static string Multiply(string a, string b)
        {
            int[] result = new int[a.Length + b.Length];
            int carry = 0;

            for (int i = 0; i < b.Length; i++)
            {
                int offset = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    offset = result.Length - 1 - (j + i);
                    int va = c2a(a[a.Length - 1 - j]);
                    int vb = c2a(b[b.Length - 1 - i]);

                    int temp = va * vb + result[offset] + carry;

                    // Keypoint: use >= instead of >
                    if (temp >= 10)
                    {
                        result[offset] = temp % 10;
                        carry = temp / 10;
                    }
                    else
                    {
                        result[offset] = temp;
                        carry = 0;
                    }
                }

                // Keypoint: Don't forget to set the carry to the most significant digit and reset the carry
                result[offset - 1] = carry;
                carry = 0;
            }

            StringBuilder sb = new StringBuilder();

            // Keypoint: need this leadingZero indicator to only ignore leading zeros.
            bool leadingZero = true;
            foreach (int i in result)
            {
                if (i == 0 && leadingZero)
                    continue;
                else
                {
                    leadingZero = false;
                    sb.Append(i);
                }
            }

            return sb.ToString();
        }

        static int c2a(char c)
        {
            return c - '0';
        }

        public static void UnitTest()
        {
            Random rand = new Random();
            int n = 0;
            while (n < 100)
            {
                int a = rand.Next(10000);
                int b = rand.Next(10000);

                string result = (a * b).ToString();

                string actual =  Multiply(a.ToString(), b.ToString());

                if(actual != result)
                    Console.WriteLine("MissMatch");

                n++;
            }
        }
    }
}
