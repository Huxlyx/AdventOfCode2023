namespace AdventOfCode2023.Src
{
    internal interface IAoC
    {
        abstract void Part1();
        abstract void Part2();

        public string[] getContent()
        {
            return File.ReadAllLines($"Res/{GetType().Name}.txt");
        }
    }
}
