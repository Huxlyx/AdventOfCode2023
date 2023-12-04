namespace AdventOfCode2023.Src
{
    internal class Day04 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            string[] content = aoc.GetContent();
            IEnumerable<string[]> cards = content.Select(line => line[(line.IndexOf(':') + 1)..].Split('|'));

            int sum = 0;
            foreach (string[] card in cards)
            {
                HashSet<string> winningNums = new();
                foreach (string winningNum in card[0].Trim().Split())
                {
                    winningNums.Add(winningNum);
                }

                int points = 0;
                foreach (string myNum in card[1].Trim().Split())
                {
                    if (!string.IsNullOrEmpty(myNum) && winningNums.Contains(myNum))
                    {
                        points++;
                    }
                }
                if (points > 0)
                {
                    sum += 1 << points - 1;
                }
            }
            Console.WriteLine(sum);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] content = aoc.GetContent();
            IEnumerable<string[]> cards = content.Select(line => line[(line.IndexOf(':') + 1)..].Split('|'));

            List<(string[] winningNums, string[] nums, int id, int? matches)> scratchCards = new();
            int id = 1;
            foreach (string[] card in cards)
            {
                string[] winningNums = card[0].Trim().Split();
                string[] nums = card[1].Trim().Split();
                scratchCards.Add((winningNums, nums, id++, null));
            }

            Queue<(string[] winningNums, string[] nums, int id, int? matches)> cardStack = new(scratchCards);

            int sum = 0;
            while (cardStack.Count > 0)
            {
                ++sum;
                (string[] winningNums, string[] nums, int id, int? matches) current = cardStack.Dequeue();
                if (current.matches == null)
                {
                    /* Count matches */
                    HashSet<string> winningNums = new(current.winningNums);
                    int matches = 0;
                    foreach (string myNum in current.nums)
                    {
                        if (!string.IsNullOrEmpty(myNum) && winningNums.Contains(myNum))
                        {
                            matches++;
                        }
                    }
                    current.matches = matches;
                    scratchCards[current.id - 1] = current;
                }

                for (int i = 0; i < current.matches; ++i)
                {
                    cardStack.Enqueue(scratchCards[current.id + i]);
                }
            }

            Console.WriteLine("done " + sum);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
