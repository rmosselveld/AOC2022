using AOC;

namespace AOC2022.Solvers
{
    public class Day2 : Solver
    {
        public override short Day { get; } = 2;

        public override int Solve1()
        {
            var input = GetInput();

            var opponent = input.Select(i => i.Split(' ')[0]);
            var response = input.Select(i => ToNormal(i.Split(' ')[1]));

            var turn = opponent.Zip(response);

            return Convert.ToInt32(turn.Sum(t => GetScore(t)));
        }

        public override int Solve2()
        {
            var input = GetInput();

            var opponent = input.Select(i => i.Split(' ')[0]).ToArray();
            var response = new string[opponent.Length];

            var deseriredOutcome = input.Select(i => i.Split(' ')[1]).ToArray();

            for (int i = 0; i < opponent.Length; i++)
            {
                if (deseriredOutcome[i] == "Y")
                    response[i] = opponent[i];
                else if (deseriredOutcome[i] == "X")
                {
                    if (opponent[i] == "A")
                        response[i] = "C";
                    else if (opponent[i] == "B")
                        response[i] = "A";
                    else
                        response[i] = "B";
                }
                else
                {
                    if (opponent[i] == "A")
                        response[i] = "B";
                    else if (opponent[i] == "B")
                        response[i] = "C";
                    else
                        response[i] = "A";
                }
            }

            return Convert.ToInt32(opponent.Zip(response).Sum(t => GetScore(t)));
        }

        static string ToNormal(string input) => input switch
        {
            "X" => "A",
            "Y" => "B",
            "Z" => "C",
            _ => throw new ArgumentOutOfRangeException(nameof(input), $"Not expected input value: {input}"),
        };

        static decimal GetScore((string First, string Second) d)
        {
            var drawScore = d.Second == "A" ? 1 : (d.Second == "B" ? 2 : 3);

            if (IsWin(d.First, d.Second))
                return drawScore + 6;
            else if (d.First == d.Second)
                return drawScore + 3;
            else
                return drawScore;
        }

        static bool IsWin(string first, string second)
        {
            return (first == "A" && second == "B") ||
                   (first == "B" && second == "C") ||
                   (first == "C" && second == "A");
        }
    }
}
