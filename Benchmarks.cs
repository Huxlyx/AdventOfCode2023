using AdventOfCode2023.Src;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode2023
{
    public class Benchmarks
    {

        [Benchmark]
        public void BenchmarkDay01_1()
        {
            var aoc = new Day01();
            aoc.Part1(aoc);
        }

        [Benchmark]
        public void BenchmarkDay01_1_Optimized()
        {
            var aoc = new Day01();
            aoc.Part1Optimized(aoc);
        }

        [Benchmark]
        public void BenchmarkDay01_2()
        {
            var aoc = new Day01();
            aoc.Part2(aoc);
        }

        [Benchmark]
        public void BenchmarkDay01_2_Optimized()
        {
            var aoc = new Day01();
            aoc.Part2Optimized(aoc);
        }

        [Benchmark]
        public void BenchmarkDay04_1()
        {
            var aoc = new Day04();
            aoc.Part1(aoc);
        }

        [Benchmark]
        public void BenchmarkDay04_2()
        {
            var aoc = new Day04();
            aoc.Part2(aoc);
        }
    }
}
