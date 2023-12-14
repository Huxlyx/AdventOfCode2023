using System.Text;

namespace AdventOfCode2023.Src
{
    internal class Day12 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            int totalSolutions = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                int[] numDigits = parts[1].Split(',').Select(int.Parse).ToArray();

                totalSolutions += BruteForce(parts[0], numDigits);
            }
            Console.WriteLine("total: " + totalSolutions);
        }

        int BruteForce(string part, int[] numDigits)
        {
            int idx = part.IndexOf('?');
            int result = 0;
            if (idx == -1)
            {
                string[] segments = part.Split('.', numDigits.Length, StringSplitOptions.RemoveEmptyEntries);
                if (segments.Length != numDigits.Length)
                {
                    return 0;
                }
                for (int i = 0; i < segments.Length; i++)
                {
                    if (segments[i].Length != numDigits[i])
                    {
                        return 0;
                    }
                }
                //Console.WriteLine("Got Solution: " + part);
                return 1;
            } 
            else
            {
                string str1 = part[0..idx] + '#' + part[(idx + 1)..];
                string str2 = part[0..idx] + '.' + part[(idx + 1)..];
                result += BruteForce(str1, numDigits);
                result += BruteForce(str2, numDigits);
            }
            return result;
        }

        public static int CalcPossibilities(string[] segments, int[] numDigits)
        {
            int totalSolutions = 1;
            for (int i = 0; i < numDigits.Length; i++)
            {
                int len = numDigits[i];
                int segmentLen = segments[i].Length;
                int solutions = segmentLen - len + 1;
                totalSolutions *= solutions;
            }
            return totalSolutions;
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            int totalSolutions = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');

                string actualPart = parts[0];
                string actualDigits = parts[1];

                for (int i = 0; i < 4; ++i)
                {
                    actualPart += '?' + parts[0];
                    actualDigits += ',' + parts[1];
                }
                
                int[] numDigits = actualDigits.Split(',').Select(int.Parse).ToArray();

                Console.WriteLine(actualPart + " " + actualDigits);

                int solutions = BruteForce(actualPart, numDigits);
                Console.WriteLine(solutions);

                totalSolutions += solutions;
            }
            Console.WriteLine("total: " + totalSolutions);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
