using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Src
{
    class Day06 : IAoC
    {

        public void Part1(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            int[] times = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            int[] records = lines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();

            int result = 1;
            for (int time = 0; time < times.Length; ++time)
            {

                int faster = 0;
                for (int i = 0; i < times[time]; ++i)
                {
                    int distance = i * (times[time] - i);
                    if (distance > records[time])
                    {
                        ++faster;
                    }
                }

                result *= faster;
            }
            Console.WriteLine(result);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            long times = lines[0].Replace(" ", "").Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => long.Parse(i)).First();
            long records = lines[1].Replace(" ", "").Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => long.Parse(i)).First();

            int faster = 0;
            for (long i = 0; i < times; ++i)
            {
                long distance = i * (times - i);
                if (i % 1_000_000 == 0)
                {
                    Console.WriteLine(i + " of " + times);
                }
                if (distance > records)
                {
                    ++faster;
                }
            }
            Console.WriteLine(faster);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
