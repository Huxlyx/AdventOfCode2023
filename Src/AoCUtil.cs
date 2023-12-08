using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Src
{
    internal static class AoCUtil
    {
        internal static long LCMOfArray(int[] numbers)
        {
            long result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                /* GCD */
                long a = result;
                long b = numbers[i];
                while (b != 0)
                {
                    long temp = b;
                    b = a % b;
                    a = temp;
                }

                result = (result * numbers[i]) / a;
            }

            return result;
        }

    }
}
