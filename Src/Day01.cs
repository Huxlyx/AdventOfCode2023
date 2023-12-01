namespace AdventOfCode2023.Src
{
    internal class Day01 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            int sum = 0;
            string[] content = aoc.GetContent();
            foreach (string s in content)
            {
                string working = "";
                foreach (char c in s)
                {
                    if (c >= '0' &&  c <= '9')
                    {
                        working += c;
                    }
                }
                sum += int.Parse("" + working[0] + working[^1]);
            }
            Console.WriteLine(sum);
        }

        public void Part2(IAoC aoc)
        {
            int sum = 0;
            string[] content = aoc.GetContent();
            foreach (string str in content)
            {

                string working = "";
                for (int i = 0; i <  str.Length; i++)
                {
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        working += str[i];
                        continue;
                    }

                    switch (str[i..])
                    {
                        case string s when s.StartsWith("one"):
                            working += '1';
                            i += 1;
                            break;
                        case string s when s.StartsWith("two"):
                            working += '2';
                            i += 1;
                            break;
                        case string s when s.StartsWith("three"):
                            working += '3';
                            i += 3;
                            break;
                        case string s when s.StartsWith("four"):
                            working += '4';
                            i += 3;
                            break;
                        case string s when s.StartsWith("five"):
                            working += '5';
                            i += 2;
                            break;
                        case string s when s.StartsWith("six"):
                            working += '6';
                            i += 2;
                            break;
                        case string s when s.StartsWith("seven"):
                            working += '7';
                            i += 3;
                            break;
                        case string s when s.StartsWith("eight"):
                            working += '8';
                            i += 3;
                            break;
                        case string s when s.StartsWith("nine"):
                            working += '9';
                            i += 2;
                            break;
                    }
                }

                sum += int.Parse("" + working[0] + working[^1]);
            }
            Console.WriteLine(sum);
        }
    }
}
