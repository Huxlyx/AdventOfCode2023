using AdventOfCode2023.Src;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = new();
            //sw.Start();
            //var aoc = new Day04();
            //aoc.Part2(aoc);
            //aoc.Part2Optimized(aoc);
            //Console.WriteLine("Done after " + sw.Elapsed);


            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}