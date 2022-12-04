using AOC;

namespace AOC2022.Solvers
{
    public class Day4 : Solver
    {
        public override short Day { get; } = 4;

        public override int Solve1()
        {
            var input = GetInput();
            var elfpair = input.Select(x => x.Split(',')[0]).Zip(input.Select(x => x.Split(',')[1]));

            var score = 0;

            foreach (var pair in elfpair)
            {
                var startLeft = Convert.ToInt32(pair.First.Split('-')[0]);
                var endLeft = Convert.ToInt32(pair.First.Split("-")[1]);

                var startRight = Convert.ToInt32(pair.Second.Split('-')[0]);
                var endRight = Convert.ToInt32(pair.Second.Split('-')[1]);

                var areasInLeft = Enumerable.Range(startLeft, endLeft - startLeft + 1);
                var areasInRight = Enumerable.Range(startRight, endRight - startRight + 1);

                var leftOverlapsRight = areasInLeft.All(n => areasInRight.Contains(n));
                var rightOverapsLeft = areasInRight.All(n => areasInLeft.Contains(n));

                if (leftOverlapsRight || rightOverapsLeft)
                    score++;
            }

            return score;
        }

        public override int Solve2()
        {
            var input = GetInput();
            var elfpair = input.Select(x => x.Split(',')[0]).Zip(input.Select(x => x.Split(',')[1]));

            var score = 0;

            foreach (var pair in elfpair)
            {
                var startLeft = Convert.ToInt32(pair.First.Split('-')[0]);
                var endLeft = Convert.ToInt32(pair.First.Split("-")[1]);

                var startRight = Convert.ToInt32(pair.Second.Split('-')[0]);
                var endRight = Convert.ToInt32(pair.Second.Split('-')[1]);

                var areasInLeft = Enumerable.Range(startLeft, endLeft - startLeft + 1);
                var areasInRight = Enumerable.Range(startRight, endRight - startRight + 1);

                var leftOverlapsRight = areasInLeft.Any(n => areasInRight.Contains(n));
                var rightOverapsLeft = areasInRight.Any(n => areasInLeft.Contains(n));

                if (leftOverlapsRight || rightOverapsLeft)
                    score++;
            }

            return score;
        }
    }
}
