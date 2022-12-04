using AOC;

namespace AOC2022.Solvers
{
    public class Day3 : Solver
    {
        public override short Day { get; } = 3;

        public override int Solve1()
        {
            var input = GetInput();

            var sackInput = input.Select(i => i.Substring(0, i.Length / 2)).Zip(input.Select(i => i.Substring(i.Length / 2)));
            var totalPriority = 0;

            foreach (var sack in sackInput)
            {
                var appearsInBoth = sack.First.Where(left => sack.Second.Any(right => right == left)).Distinct().Single();

                totalPriority += GetPriority(appearsInBoth);
            }

            return totalPriority;
        }

        public override int Solve2()
        {
            var groups = GetInput().Chunk(3);

            var totalPriority = 0;

            foreach (var group in groups)
            {
                var common = group[0].ToArray().Where(itemInFirst => group[1].ToList().Any(itemInSecond => itemInFirst == itemInSecond) &&
                                                                     group[2].ToList().Any(itemInThird => itemInFirst == itemInThird)).Distinct().Single();

                totalPriority += GetPriority(common);
            }

            return totalPriority;
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
