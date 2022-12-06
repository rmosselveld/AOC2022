
namespace AOC2022.Solvers
{
    public class Day3 : Solver
    {
        public override short Day { get; } = 3;

        public override object Solve1()
        {
            var input = GetInput();

            var sackInput = input.Select(i => i.Substring(0, i.Length / 2)).Zip(input.Select(i => i.Substring(i.Length / 2)));

            return sackInput.Select(sack => GetPriority(sack.First.Intersect(sack.Second).Single())).Sum();
        }

        public override object Solve2()
        {
            var groups = GetInput().Chunk(3);

            return groups.Select(group => GetPriority(group[0].Intersect(group[1]).Intersect(group[2]).Single())).Sum();
        }

        static int GetPriority(char character)
        {
            if (char.IsUpper(character))
                return (int)character - 38;
            else
                return (int)character - 96;
        }
    }
}
