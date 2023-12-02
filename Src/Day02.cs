using System.Text;

namespace AdventOfCode2023.Src
{
    internal class Day02 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;

            int sum = 0;
            string[] content = aoc.GetContent();
            IEnumerable<string[]> games = content.Select(line => line[(line.IndexOf(':') + 1)..].Split(';'));

            int gameIdx = 0;
            foreach (string[] rounds in games)
            {
                ++gameIdx;
                foreach (string round in rounds)
                {
                    string[] cubes = round.Split(',');
                    foreach (string cube in cubes)
                    {
                        string trimmed = cube.Trim();
                        int num = int.Parse(trimmed[..trimmed.IndexOf(' ')]);
                        switch (cube)
                        {
                            case string s when s.EndsWith("red"):
                                if (num > maxRed)
                                {
                                    goto round;
                                }
                                break;
                            case string s when s.EndsWith("green"):
                                if (num > maxGreen)
                                {
                                    goto round;
                                }
                                break;
                            case string s when s.EndsWith("blue"):
                                if (num > maxBlue)
                                {
                                    goto round;
                                }
                                break;
                        }
                    }
                }
                sum += gameIdx;
            round:
                continue;

            }

            Console.WriteLine(sum);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {

            int sum = 0;
            string[] content = aoc.GetContent();
            IEnumerable<string[]> games = content.Select(line => line[(line.IndexOf(':') + 1)..].Split(';'));

            foreach (string[] rounds in games)
            {
                int maxRed = 1;
                int maxGreen = 1;
                int maxBlue = 1;

                foreach (string round in rounds)
                {
                    string[] cubes = round.Split(',');

                    foreach (string cube in cubes)
                    {
                        string trimmed = cube.Trim();
                        int num = int.Parse(trimmed[..trimmed.IndexOf(' ')]);
                        switch (cube)
                        {
                            case string s when s.EndsWith("red"):
                                if (num > maxRed)
                                {
                                    maxRed = num;
                                }
                                break;
                            case string s when s.EndsWith("green"):
                                if (num > maxGreen)
                                {
                                    maxGreen = num;
                                }
                                break;
                            case string s when s.EndsWith("blue"):
                                if (num > maxBlue)
                                {
                                    maxBlue = num;
                                }
                                break;
                        }
                    }
                }
                sum += maxRed * maxGreen * maxBlue;
            }
            Console.WriteLine(sum);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
