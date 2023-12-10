namespace AdventOfCode2023.Src
{
    internal class Day10 : IAoC
    {

        enum Direction
        {
            Left, Right, Up, Down
        }

        public void Part1(IAoC aoc)
        {
            char[][] map = aoc.GetContent().Select(s => s.ToCharArray()).ToArray();

            (int y, int x) to = (0, 0);
            for (int y = 0; y < map.Length && to == (0, 0); ++y)
            {
                for (int x = 0; x < map[y].Length; ++x)
                {
                    if (map[y][x] == 'S')
                    {
                        to = (y, x);
                        break;
                    }
                }
            }

            long count = 0;
            Direction dir = Direction.Right;
            bool done = false;
            while ( ! done)
            {
                ++count;
                to = NextFromDir(to, dir);
                char nextChar = map[to.y][to.x];

                if (nextChar == 'S')
                {
                    Console.WriteLine("Reached start " + count + " Farthest:" + count / 2);
                    done = true;
                    break;
                }

                dir = NextDir(nextChar, dir);
            }
        }

        private static (int, int) NextFromDir((int y, int x) from, Direction dir) => dir switch
        {
            Direction.Left => (from.y, from.x - 1),
            Direction.Right => (from.y, from.x + 1),
            Direction.Up => (from.y - 1, from.x),
            Direction.Down => (from.y + 1, from.x),
            _ => (from.y, from.x),
        };

        private static Direction NextDir(char nextChar, Direction dir)
        {
            return nextChar switch
            {
                'L' when dir == Direction.Down => Direction.Right,
                'L' when dir == Direction.Left => Direction.Up,
                'J' when dir == Direction.Right => Direction.Up,
                'J' when dir == Direction.Down => Direction.Left,
                '7' when dir == Direction.Right => Direction.Down,
                '7' when dir == Direction.Up => Direction.Left,
                'F' when dir == Direction.Up => Direction.Right,
                'F' when dir == Direction.Left => Direction.Down,
                _ => dir,
            };
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            char[][] map = aoc.GetContent().Select(s => s.ToCharArray()).ToArray();

            (int y, int x) to = (0, 0);
            for (int y = 0; y < map.Length && to == (0, 0); ++y)
            {
                for (int x = 0; x < map[y].Length; ++x)
                {
                    if (map[y][x] == 'S')
                    {
                        to = (y, x);
                        break;
                    }
                }
            }

            bool[][] visited = new bool[map.Length][];

            for (int i = 0; i < map.Length; ++i)
            {
                visited[i] = new bool[map[0].Length];
            }


            long count = 0;
            Direction dir = Direction.Right;
            bool done = false;
            while (!done)
            {
                ++count;
                to = NextFromDir(to, dir);
                visited[to.y][to.x] = true;
                char nextChar = map[to.y][to.x];

                if (nextChar == 'S')
                {
                    Console.WriteLine("Reached start " + count + " Farthest:" + count / 2);
                    done = true;
                    break;
                }

                dir = NextDir(nextChar, dir);
            }

            char[][] expand = new char[map.Length * 2 - 1][];

            for (int y = 0; y < expand.Length; y++)
            {
                expand[y] = new char[map[0].Length * 2 - 1];

                for (int x = 0; x < expand[y].Length; ++x)
                {

                    if (y % 2 == 0 && x % 2 == 0)
                    {
                        expand[y][x] = visited[y / 2][x / 2] ? map[y / 2][x / 2] : ' ';
                        continue;
                    } 
                    else if (y % 2 == 1 && x % 2 == 0) /* expand down */
                    {
                        char prev = map[y / 2][x / 2];
                        char next = map[y / 2 + 1][x / 2];
                        if (visited[y / 2][x / 2] 
                            && (prev == '|' || prev == 'F' || prev == '7' || prev == 'S')
                            && (next == '|' || next == 'L' || next == 'J' || next == 'S')) {
                            expand[y][x] = '|';
                            continue;
                        }
                    }
                    else if (y % 2 == 0)   /* expand right */
                    {
                        char prev = map[y / 2][x / 2];
                        char next = map[y / 2][x / 2 + 1];
                        if (visited[y / 2][x / 2] 
                            && (prev == '-' || prev == 'L' || prev == 'F' || prev == 'S')
                            && (next == '-' || next == 'J' || next == '7' || next == 'S'))
                        {
                            expand[y][x] = '-';
                            continue;
                        }
                    }
  
                    expand[y][x] = ' ';
                }
            }

            /* flood from the middle and hope it starts somewhere inside the loop */
            Flood(expand, (expand.Length / 2, expand[0].Length / 2));

            int res = 0;
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (visited[y][x] == false && expand[y * 2][x * 2] == '#')
                    {
                        ++res;
                    }
                }
            }

            Console.WriteLine(res);
        }

        private void Flood(char[][] map, (int y, int x) next)
        {
            if (next.y < 0 || next.x < 0 || next.y >= map.Length || next.x >= map[0].Length)
            {
                return;
            }

            if (map[next.y][next.x] == ' ')
            {
                map[next.y][next.x] = '#';
                Flood(map, (next.y, next.x - 1));
                Flood(map, (next.y, next.x + 1));
                Flood(map, (next.y + 1, next.x));
                Flood(map, (next.y - 1, next.x));
            }
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
