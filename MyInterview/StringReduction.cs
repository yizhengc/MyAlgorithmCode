using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class StringReduction
    {
        public static int ReduceString(string input)
        {
            char[] charlist = input.ToCharArray();
            for (int i = 1; i < input.Length; )
            {
                int idxPrev = Previous(i, charlist);
                if (idxPrev < 0 || charlist[idxPrev] == charlist[i])
                    i++;
                else if (charlist[idxPrev] != charlist[i])
                {
                    charlist[i] = (char)Replace(charlist[idxPrev], charlist[i]);
                    charlist[idxPrev] = '0';
                }
            }

            int length = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (charlist[i] != '0')
                    length++;
            }

            return length;
        }

        static int Previous(int index, char[] input)
        {
            for (int i = index - 1; i >= 0; i--)
            {
                if (input[i] != '0')
                    return i;
            }

            return -1;
        }

        static char? Replace(char first, char second)
        {
            if (first == 'a')
            {
                if (second == 'b')
                    return 'c';
                else if (second == 'c')
                    return 'b';
            }
            else if (first == 'b')
            {
                if (second == 'a')
                    return 'c';
                else if (second == 'c')
                    return 'a';
            }
            else if (first == 'c')
            {
                if (second == 'a')
                    return 'b';
                else if (second == 'b')
                    return 'a';
            }

            return null;
        }
    }
}
