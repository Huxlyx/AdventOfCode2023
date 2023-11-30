namespace AdventOfCode2023.Src
{
    internal interface IAoC
    {
        abstract void Part1();
        abstract void Part2();

        public string[] GetContent()
        {
            return File.ReadAllLines($"Res/{GetType().Name}.txt");
        }
    }
}
