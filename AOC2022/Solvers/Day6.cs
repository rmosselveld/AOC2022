namespace AOC2022.Solvers
{
    public class Day6 : Solver
    {
        public override short Day { get; } = 6;

        public override object Solve1()
        {
            return GetCharactersProcessed(GetInput().First(), 4);
        }

        public override object Solve2()
        {
            return GetCharactersProcessed(GetInput().First(), 14);
        }

        private int GetCharactersProcessed(string input, int size)
        {
            for (int i = 0; i < input.Length - size - 1; i++)
            {
                if (input.Skip(i).Take(size).Distinct().Count() == size)
                    return i + size;
            }

            return 0;
        }
    }
}
