using AdventOfCode2023.Src;
//using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new();
            sw.Start();
            var aoc = new Day06();
            aoc.Part1(aoc);
            Console.WriteLine("Done after " + sw.Elapsed);


            //BenchmarkRunner.Run<Benchmarks>();
        }
    }
}