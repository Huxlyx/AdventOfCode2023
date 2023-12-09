namespace AdventOfCode2023.Src
{
    internal class Day09 : IAoC
    {
        public void Part1(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            int sumNextValues = 0;
            foreach (string line in lines)
            {
                int[] ints = line.Split().Select(int.Parse).ToArray();
                sumNextValues += PredictNextValue(ints);
            }

            Console.WriteLine(sumNextValues);
        }

        static int PredictNextValue(int[] input)
        {
            int[] deltas = new int[input.Length - 1];
            bool allZero = true;
            for (int i = 0; i < deltas.Length; i++)
            {
                int delta = input[i + 1] - input[i];
                allZero &= delta == 0;
                deltas[i] = delta;
            }

            return allZero ? input[^1] : PredictNextValue(deltas) + input[^1];
        }

        public void Part1Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }

        public void Part2(IAoC aoc)
        {
            string[] lines = aoc.GetContent();

            int sumNextValues = 0;
            foreach (string line in lines)
            {
                int[] ints = line.Split().Select(int.Parse).ToArray();
                Array.Reverse(ints);
                sumNextValues += PredictNextValue(ints);
            }

            Console.WriteLine(sumNextValues);
        }

        public void Part2Optimized(IAoC aoc)
        {
            throw new NotImplementedException();
        }
    }
}
