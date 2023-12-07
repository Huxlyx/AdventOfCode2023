namespace AdventOfCode2023.Src
{
    internal class Day07 : IAoC
    {
        public static string VALUE_ORDER = "AKQJT98765432";

        public static char FIVE_OF_A_KIND = 'A';
        public static char FOUR_OF_A_KIND = 'B';
        public static char FUL_HOUSE = 'C';
        public static char THREE_OF_A_KIND = 'D';
        public static char TWO_PAIR = 'E';
        public static char ONE_PAIR = 'F';
        public static char HIGH_CARD = 'G';

        public static char HandToType (string hand)
        {
            int[] count = new int[13];

            foreach (char c in hand)
            {
                count[c - 'A']++;
            }

            bool pair = false;
            bool tripple = false;

            foreach (int i in count)
            {
                switch (i)
                {
                    case 2: 
                        if (pair)
                        {
                            return TWO_PAIR;
                        }
                        pair = true; 
                    break;
                    case 3: tripple = true; break;
                    case 4: return FOUR_OF_A_KIND;
                    case 5: return FIVE_OF_A_KIND;

                }
            }

            if (tripple && pair)
            {
                return FUL_HOUSE;
            }
            if (tripple)
            {
                return THREE_OF_A_KIND;
            }
            if (pair)
            {
                return ONE_PAIR;
            }
            return HIGH_CARD;
        }


        public readonly struct Hand : IComparable
        {
            public readonly string Cards { get; init; }
            public readonly int Bid { get; init; }
            public readonly string Val { get; init; }

            public Hand(string cards, int bid)
            {
                Cards = cards;
                Bid = bid;

                /* turn type and cards into string we can sort alphabetically based on their value */
                string cardVal = "";
                foreach (char c in cards)
                {
                    cardVal += Convert.ToChar('A' + VALUE_ORDER.IndexOf(c));
                }

                Val = HandToType(cardVal) + cardVal;
            }

            public override string ToString()
            {
                return Cards + " " + Bid + " " + Val;
            }

            public int CompareTo(object? other)
            {
                if (other is Hand hand)
                {
                    return string.Compare(Val, hand.Val);
                }
                throw new NotImplementedException();
            }
        }

        public void Part1(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            List<Hand> hands = new();
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                hands.Add(new(parts[0], int.Parse(parts[1])));
            }

            hands.Sort();
            hands.Reverse();

            long result = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                result += hands[i].Bid * (i + 1);
            }

            foreach (Hand hand in hands)
            {
                Console.WriteLine(hand);
            }
            Console.WriteLine(result);
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
