using AOC;

namespace Day1.Solvers
{
    public class Day1 : Solver
    {
        public override short Day { get; } = 1;

        public override int Solve1()
        {
            return GetFoodPerElf().OrderByDescending(e => e).First();
        }

        public override int Solve2()
        {
            return GetFoodPerElf().OrderByDescending(e => e).Take(3).Sum();
        }

        private List<int> GetFoodPerElf()
        {
            string[] elfsFood = GetInput();

            List<int> foodByElf = new List<int>();

            var index = 0;

            while(index < elfsFood.Length)
            {
                var group = elfsFood.Skip(index).TakeWhile(ef => !string.IsNullOrEmpty(ef)).Select(f => Convert.ToInt32(f));
                foodByElf.Add(group.Sum());
                index += group.Count() + 1;
            }

            return foodByElf;
        }
    }
}
