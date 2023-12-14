using System.Text;

namespace AdventOfCode2023.Src
{
    internal class Day14 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            char[][] lines = aoc.GetContent().Select(s => s.ToCharArray()).ToArray();

            bool didMove = false;
            int loops = 0;
            do
            {
                didMove = false;
                for (int i = 1; i < lines.Length; ++i)
                {
                    for (int col = 0; col < lines[i].Length; ++col)
                    {
                        if (lines[i][col] == 'O' && lines[i - 1][col] == '.')
                        {
                            lines[i - 1][col] = 'O';
                            lines[i][col] = '.';
                            didMove |= true;
                        }
                    }
                }
                loops++;
            }
            while (didMove);

            Console.WriteLine("Done after " + loops);

            long sum = 0;
            for (int i = 0; i < lines.Length; ++i)
            {
                foreach (char c in lines[i])
                {
                    if (c == 'O')
                    {
                        sum += lines.Length - i;
                    }
                }
            }

            Console.WriteLine("Result " + sum);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            char[][] lines = aoc.GetContent().Select(s => s.ToCharArray()).ToArray();

            bool didMove = false;
            int loops = 0;

            for (int cycles = 0; cycles < 1_000; ++cycles)
            {
                /* north */
                do
                {
                    didMove = false;
                    for (int i = 1; i < lines.Length; ++i)
                    {
                        for (int col = 0; col < lines[i].Length; ++col)
                        {
                            if (lines[i][col] == 'O' && lines[i - 1][col] == '.')
                            {
                                lines[i - 1][col] = 'O';
                                lines[i][col] = '.';
                                didMove |= true;
                            }
                        }
                    }
                    loops++;
                }
                while (didMove);

                /* west */
                do
                {
                    didMove = false;
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        for (int col = 1; col < lines[i].Length; ++col)
                        {
                            if (lines[i][col] == 'O' && lines[i][col - 1] == '.')
                            {
                                lines[i][col - 1] = 'O';
                                lines[i][col] = '.';
                                didMove |= true;
                            }
                        }
                    }
                    loops++;
                }
                while (didMove);

                /* south */
                do
                {
                    didMove = false;
                    for (int i = lines.Length - 2; i >= 0; --i)
                    {
                        for (int col = 0; col < lines[i].Length; ++col)
                        {
                            if (lines[i][col] == 'O' && lines[i + 1][col] == '.')
                            {
                                lines[i + 1][col] = 'O';
                                lines[i][col] = '.';
                                didMove |= true;
                            }
                        }
                    }
                    loops++;
                }
                while (didMove);

                /* east */
                do
                {
                    didMove = false;
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        for (int col = lines[i].Length - 2; col >= 0; --col)
                        {
                            if (lines[i][col] == 'O' && lines[i][col + 1] == '.')
                            {
                                lines[i][col + 1] = 'O';
                                lines[i][col] = '.';
                                didMove |= true;
                            }
                        }
                    }
                    loops++;
                }
                while (didMove);
            }

            long sum = 0;
            for (int i = 0; i < lines.Length; ++i)
            {
                foreach (char c in lines[i])
                {
                    if (c == 'O')
                    {
                        sum += lines.Length - i;
                    }
                }
            }
            Console.WriteLine("Result " + sum);
        }

        private string GridToString(char[][] grid)
        {
            StringBuilder sb = new(grid.Length * grid[0].Length);
            for (int i = 0; i < grid.Length; ++i)
            {
                foreach (char c in grid[i])
                {
                    sb.Append(c);
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }

        private void Print(char[][] grid)
        {
            StringBuilder sb = new(grid.Length * grid[0].Length);
            for (int i = 0; i < grid.Length; ++i)
            {
                foreach (char c in grid[i])
                {
                    sb.Append(c);
                }
                sb.Append('\n');
            }

            Console.WriteLine(sb.ToString());
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
