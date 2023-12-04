using System.Runtime.CompilerServices;
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
            int sum = 0;
            string[] content = aoc.GetContent();
            foreach (string s in content)
            {
                int firstNum = 0;
                int lastNum = 0;
                foreach (char c in s)
                {
                    if (c >= '0' && c <= '9')
                    {
                        if (firstNum == 0)
                        {
                            firstNum = c - '0';
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = c - '0';
                        }
                    }
                }
                sum += firstNum * 10 + lastNum;
            }
            //Console.WriteLine(sum);
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
            int sum = 0;
            string[] content = aoc.GetContent();
            foreach (string str in content)
            {
                int firstNum = 0;
                int lastNum = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        if (firstNum == 0)
                        {
                            firstNum = str[i] - '0';
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = str[i] - '0';
                        }
                        continue;
                    }

                    if (StringAtPosEquals(str, i, "one"))
                    {
                        ++i;
                        if (firstNum == 0)
                        {
                            firstNum = 1;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 1;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "two")) 
                    {
                        ++i;
                        if (firstNum == 0)
                        {
                            firstNum = 2;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 2;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "three"))
                    {
                        i += 3;
                        if (firstNum == 0)
                        {
                            firstNum = 3;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 3;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "four"))
                    {
                        i += 3;
                        if (firstNum == 0)
                        {
                            firstNum = 4;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 4;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "five"))
                    {
                        i += 2;
                        if (firstNum == 0)
                        {
                            firstNum = 5;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 5;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "six"))
                    {
                        i += 2;
                        if (firstNum == 0)
                        {
                            firstNum = 6;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 6;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "seven"))
                    {
                        i += 3;
                        if (firstNum == 0)
                        {
                            firstNum = 7;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 7;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "eight"))
                    {
                        i += 3;
                        if (firstNum == 0)
                        {
                            firstNum = 8;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 8;
                        }
                    }
                    else if (StringAtPosEquals(str, i, "nine"))
                    {
                        i += 2;
                        if (firstNum == 0)
                        {
                            firstNum = 9;
                            lastNum = firstNum;
                        }
                        else
                        {
                            lastNum = 9;
                        }
                    }
                }
                sum += firstNum * 10 + lastNum;
            }
            //Console.WriteLine(sum);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool StringAtPosEquals(string input, int pos, string compare)
        {
            if (compare.Length + pos > input.Length) {
                return false;
            }

            for (int i = 0; i < compare.Length; i++)
            {
                if (input[pos + i] != compare[i]) 
                { 
                    return false; 
                }
            }
            return true;
        }
    }
}
