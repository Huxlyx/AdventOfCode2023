namespace AdventOfCode2023.Src
{
    internal class Day03 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            string[] content = aoc.GetContent();

            int rowLength = content[0].Length;

            int sum = 0;
            for (int i = 0; i < content.Length; ++i)
            {
                bool isNum = false;
                int numStart = 0;
                string currentRow = content[i];
                for (int j = 0; j < rowLength; ++j)
                {
                    if (char.IsDigit(currentRow[j]))
                    {
                        if ( ! isNum)
                        {
                            isNum = true;
                            numStart = j;
                        }
                    }
                    else if (isNum)
                    {
                        isNum = false;
                        bool adj = IsAdjacentToSymbol(content, i, numStart, j);
                        int num = int.Parse(currentRow[numStart..j]);
                        Console.WriteLine($"found num {num}{(adj ? " adjacent" : "")}");
                        if (adj)
                        {
                            sum += num;
                        }
                    }
                }
                if (isNum)
                {
                    bool adj = IsAdjacentToSymbol(content, i, numStart, rowLength);
                    int num = int.Parse(currentRow[numStart..]);
                    Console.WriteLine($"found num {num}{(adj ? " adjacent" : "")}");
                    if (adj)
                    {
                        sum += num;
                    }
                }
            }
            Console.WriteLine(sum);
        }

        private static bool IsAdjacentToSymbol(string[] content, int row, int start, int end)
        {
            /* scan left to right */
            for (int i = Math.Max(start - 1, 0); i < Math.Min(end + 1, content[0].Length); ++i)
            {
                if (row > 0 && content[row - 1][i] != '.') /* check above */
                {
                    return true;
                }
                if (row < content.Length - 1 && content[row + 1][i] != '.')   /* check below */
                {
                    return true;
                }
            }

            /* check position left and right */
            if (start > 0 && content[row][start - 1] != '.')
            {
                return true;
            }
            if (end < content[0].Length - 1 && content[row][end] != '.')
            {
                return true;
            }

            return false;
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] content = aoc.GetContent();
            int rowLength = content[0].Length;

            Dictionary<(int row, int col), List<int>> GearToPos = new();

            for (int i = 0; i < content.Length; ++i)
            {
                bool isNum = false;
                int numStart = 0;
                string currentRow = content[i];
                for (int j = 0; j < rowLength; ++j)
                {
                    if (char.IsDigit(currentRow[j]))
                    {
                        if (!isNum)
                        {
                            isNum = true;
                            numStart = j;
                        }
                    }
                    else if (isNum)
                    {
                        isNum = false;
                        int num = int.Parse(currentRow[numStart..j]);
                        MaybeHandleGear(content, i, numStart, j, GearToPos, num);

                    }
                }
                if (isNum)
                {
                    int num = int.Parse(currentRow[numStart..]);
                    MaybeHandleGear(content, i, numStart, rowLength, GearToPos, num);
                }
            }

            int sum = 0;
            foreach (var entry in GearToPos)
            {
                Console.WriteLine(entry.ToString() + " " + entry.Value.Count);
                var value = entry.Value;
                if (value.Count == 2)
                {
                    sum += value[0] * value[1];
                }
            }
            Console.WriteLine(sum);
        }
        private static void MaybeHandleGear(string[] content, int row, int start, int end, Dictionary<(int x, int y), List<int>> gearToPos, int num)
        {
            /* scan left to right */
            for (int i = Math.Max(start - 1, 0); i < Math.Min(end + 1, content[0].Length); ++i)
            {
                if (row > 0 && content[row - 1][i] == '*') /* check above */
                {
                    MaybeAdd(row - 1, i, gearToPos, num);
                }
                if (row < content.Length - 1 && content[row + 1][i] == '*')   /* check below */
                {
                    MaybeAdd(row + 1, i, gearToPos, num);
                }
            }

            /* check position left and right */
            if (start > 0 && content[row][start - 1] == '*')
            {
                MaybeAdd(row, start - 1, gearToPos, num);
            }
            if (end < content[0].Length - 1 && content[row][end] == '*')
            {
                MaybeAdd(row, end, gearToPos, num);
            }
        }

        private static void MaybeAdd(int row, int col, Dictionary<(int x, int y), List<int>> gearToPos, int num)
        {
            if (gearToPos.TryGetValue((row - 1, col), out var nums))
            {
                nums.Add(num);
            }
            else
            {
                List<int> list = new()
                {
                    num
                };
                gearToPos.Add((row - 1, col), list);
            }
        }


        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
