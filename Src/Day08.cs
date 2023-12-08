using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2023.Src
{
    internal class Day08 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            string[] content = aoc.GetContent();
            char[] instructions = content[0].ToCharArray();

            Dictionary<string, (string, string)> nodes = new();
            for (int i = 2; i < content.Length; ++i)
            {
                string[] current = content[i].Split(" = ");
                nodes.Add(current[0], (current[1][1..4], current[1][6..9]));
            }

            string next = "AAA";
            int steps = 0;
            while (next != "ZZZ")
            {
                foreach (char c in instructions)
                {
                    ++steps;
                    (string, string) entry = nodes.GetValueOrDefault(next);
                    next = c == 'L' ? entry.Item1 : entry.Item2;

                    if (next == "ZZZ")
                    {
                        break;
                    }
                }
            }
            Console.Write(steps);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] content = aoc.GetContent();
            char[] instructions = content[0].ToCharArray();

            Dictionary<string, (string, string)> nodes = new();
            List<string> nodesEndingWithA = new();
            for (int i = 2; i < content.Length; ++i)
            {
                string[] current = content[i].Split(" = ");
                nodes.Add(current[0], (current[1][1..4], current[1][6..9]));
                if (current[0].EndsWith('A'))
                {
                    nodesEndingWithA.Add(current[0]);
                }
            }

            string[] nexts = new string[nodesEndingWithA.Count];
            for (int i = 0; i < nexts.Length; ++i)
            {
                nexts[i] = nodesEndingWithA[i];
            }

            int[] stepsPerNext = new int[nexts.Length];
            for (int i = 0; i < nexts.Length; ++i)
            {
                bool done = false;
                int steps = 0;
                while (!done)
                {
                    foreach (char c in instructions)
                    {
                        ++steps;
                        (string, string) entry = nodes.GetValueOrDefault(nexts[i]);
                        nexts[i] = c == 'L' ? entry.Item1 : entry.Item2;

                        if (nexts[i].EndsWith('Z'))
                        {
                            stepsPerNext[i] = steps;
                            done = true;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(AoCUtil.LCMOfArray(stepsPerNext));
        }

      
        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
