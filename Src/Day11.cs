namespace AdventOfCode2023.Src
{
    internal class Day11 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            List<string> lines = aoc.GetContent().ToList();

            /* expand horizontal */
            bool[] hasGalaxy = new bool[lines[0].Length];
            foreach(string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    hasGalaxy[i] |= line[i] != '.';
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                string newLine = "";
                for (int j = 0; j < lines[i].Length; j++)
                {
                    newLine += lines[i][j];
                    if (!hasGalaxy[j])
                    {
                        newLine += '.';
                    }
                }
                lines[i] = newLine;
            }

            /* expand vertical */
            for (int i = 0; i < lines.Count; ++i)
            {
                string line = lines[i];
                bool isVoid = true;
                foreach (char c  in line)
                {
                    if (c != '.')
                    {
                        isVoid = false;
                        break;
                    }
                }
                if (isVoid)
                {
                    string newLine = line;
                    lines.Insert(i++, newLine);
                }
            }

            List<(int y, int x)> galaxies = new();

            for (int i = 0; i < lines.Count; ++i)
            {
                for (int j = 0; j < lines[i].Length; ++j)
                {
                    if (lines[i][j] == '#')
                    {
                        galaxies.Add((i, j));
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < galaxies.Count; ++i)
            {
                for (int j = i + 1; j < galaxies.Count; ++j)
                {
                    sum += Math.Max(galaxies[i].y, galaxies[j].y) - Math.Min(galaxies[i].y, galaxies[j].y) + (Math.Max(galaxies[i].x, galaxies[j].x) - Math.Min(galaxies[i].x, galaxies[j].x));
                }
            }

            Console.WriteLine("Sum: " + sum);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            List<string> lines = aoc.GetContent().ToList();

            bool[] hasGalaxyHorizontal = new bool[lines[0].Length];
            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    hasGalaxyHorizontal[i] |= line[i] == '#';
                }
            }

            bool[] hasGalaxyVertical = new bool[lines.Count];
            for (int i = 0; i < lines.Count; ++i)
            {
                string line = lines[i];
                foreach (char c in line)
                {
                    if (c == '#')
                    {
                        hasGalaxyVertical[i] |= true;
                    }
                }
            }

            List<(int y, int x)> galaxies = new();
            for (int i = 0; i < lines.Count; ++i)
            {
                for (int j = 0; j < lines[i].Length; ++j)
                {
                    if (lines[i][j] == '#')
                    {
                        galaxies.Add((i, j));
                    }
                }
            }

            long sum = 0;
            for (int i = 0; i < galaxies.Count; ++i)
            {
                for (int j = i + 1; j < galaxies.Count; ++j)
                {
                    long distance = 0;
                    int minY = Math.Min(galaxies[i].y, galaxies[j].y);
                    int maxY = Math.Max(galaxies[i].y, galaxies[j].y);
                    for (int y = minY; y < maxY; ++y)
                    {
                        distance += hasGalaxyVertical[y] ? 1 : 1000000;
                    }

                    int minX = Math.Min(galaxies[i].x, galaxies[j].x);
                    int maxX = Math.Max(galaxies[i].x, galaxies[j].x);
                    for (int x = minX; x < maxX; ++x)
                    {
                        distance += hasGalaxyHorizontal[x] ? 1 : 1000000;
                    }

                    sum += distance;
                }
            }

            Console.WriteLine("Sum: " + sum);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
