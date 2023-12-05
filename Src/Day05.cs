using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Src
{
    class Day05 : IAoC
    {

        public struct Map
        {
            string name;
            public List<Mapping> Mappings { get; init; } = new();

            public Map(string name)
            {
                this.name = name;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long DoMap(long src)
            {
                foreach (Mapping mapping in Mappings)
                {
                    if (src >= mapping.src && src <= mapping.src + mapping.len)
                    {
                        return src + mapping.offset;
                    }
                }
                return src;
            }
        }

        public struct Mapping
        {
            public readonly long dest;
            public readonly long src;
            public readonly long len;
            public readonly long offset;

            public Mapping(long dest, long src, long len)
            {
                this.dest = dest;
                this.src = src;
                this.len = len;
                this.offset = dest - src;
            }
        }

        public void Part1(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            long[] seeds = lines[0].Split(": ")[1].Split(' ').Select(item => long.Parse(item.Trim())).ToArray();

            List<Map> maps = new();
            Map? current = null;
            for (int i = 2; i < lines.Length; ++i)
            {
                if (lines[i].Contains("map:"))
                {
                    current = new(lines[i]);
                    maps.Add(current.Value);
                }
                else if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    long[] mappings = lines[i].Split(' ').Select(item => long.Parse(item.Trim())).ToArray();
                    current!.Value.Mappings.Add(new Mapping(mappings[0], mappings[1], mappings[2]));
                }
            }

            List<long> results = new();
            foreach (long seed in seeds)
            {
                long val = seed;
                foreach (Map map in maps)
                {
                    val = map.DoMap(val);
                }
                Console.WriteLine(val);
                results.Add(val);
            }
            Console.WriteLine("result: " + results.Min());
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            long[] seeds = lines[0].Split(": ")[1].Split(' ').Select(item => long.Parse(item.Trim())).ToArray();

            List<Map> maps = new();
            Map? current = null;
            for (int i = 2; i < lines.Length; ++i)
            {
                if (lines[i].Contains("map:"))
                {
                    current = new(lines[i]);
                    maps.Add(current.Value);
                }
                else if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    long[] mappings = lines[i].Split().Select(item => long.Parse(item.Trim())).ToArray();
                    current!.Value.Mappings.Add(new Mapping(mappings[0], mappings[1], mappings[2]));
                }
            }

            long result = long.MaxValue;
            long seedCount = 0;
            for (int i = 0; i < seeds.Length; i += 2)
            {
                for (long j = 0; j <= seeds[i + 1]; ++j)
                {
                    ++seedCount;
                    long val = seeds[i] + j;
                    foreach (Map map in maps)
                    {
                        val = map.DoMap(val);
                    }

                    if (val < result)
                    {
                        result = val;
                    }
                }
                Console.WriteLine("done: " + i + " " + seedCount);
            }

            Console.WriteLine("result: " + result + " " + seedCount);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
