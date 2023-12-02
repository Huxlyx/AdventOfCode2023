using System.Text;

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

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            int sum = 0;
            string[] content = aoc.GetContent();
            foreach (string str in content)
            {

                StringBuilder sb = new(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        sb.Append(str[i]);
                        continue;
                    }

                    switch (str[i..])
                    {
                        case string s when s.StartsWith("one"):
                            sb.Append('1');
                            i += 1;
                            break;
                        case string s when s.StartsWith("two"):
                            sb.Append('2');
                            i += 1;
                            break;
                        case string s when s.StartsWith("three"):
                            sb.Append('3');
                            i += 3;
                            break;
                        case string s when s.StartsWith("four"):
                            sb.Append('4');
                            i += 3;
                            break;
                        case string s when s.StartsWith("five"):
                            sb.Append('5');
                            i += 2;
                            break;
                        case string s when s.StartsWith("six"):
                            sb.Append('6');
                            i += 2;
                            break;
                        case string s when s.StartsWith("seven"):
                            sb.Append('7');
                            i += 3;
                            break;
                        case string s when s.StartsWith("eight"):
                            sb.Append('8');
                            i += 3;
                            break;
                        case string s when s.StartsWith("nine"):
                            sb.Append('9');
                            i += 2;
                            break;
                    }
                }
                string working = sb.ToString();
                sum += int.Parse("" + working[0] + working[^1]);
            }
            Console.WriteLine(sum);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
