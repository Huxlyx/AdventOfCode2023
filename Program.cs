using AdventOfCode2023.Src;
using System.Diagnostics;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new();
            sw.Start();
            var aoc = new Day02();
            aoc.Part2(aoc);
            Console.WriteLine("Done after " + sw.Elapsed);
        }
    }
}