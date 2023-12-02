namespace AdventOfCode2023.Src
{
    internal interface IAoC
    {
        abstract void Part1(IAoC aoc);
        abstract void Part1Optimized(IAoC aoc);
        abstract void Part2(IAoC aoc);
        abstract void Part2Optimized(IAoC aoc);

        public string[] GetContent()
        {
            return File.ReadAllLines($"Res/{GetType().Name}.txt");
        }
    }
}
