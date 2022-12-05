using AOC;

namespace AOC2022.Solvers
{
    public class Day5 : Solver
    {
        public override short Day { get; } = 5;

        public override string Solve1()
        {
            var input = GetInput();
            var stacks = GetStacks(input);
            var moves = GetMoves(input);

            foreach (var move in moves)
            {
                for (int count = 0; count < move.numberOfCrates; count++)
                {
                    stacks[move.to - 1].Push(stacks[move.from - 1].Pop());
                }
            }

            return new string(stacks.Select(s => s.Peek()).ToArray());
        }

        public override string Solve2()
        {
            var input = GetInput();

            var stacks = GetStacks(input);
            var commands = GetMoves(input);

            foreach (var command in commands)
            {
                List<char> tomove = new List<char>();
                for (int count = 0; count < command.numberOfCrates; count++)
                {
                    tomove.Add(stacks[command.from - 1].Pop());

                }

                tomove.Reverse();

                foreach (var c in tomove)
                {
                    stacks[command.to - 1].Push(c);
                }
            }

            return new string(stacks.Select(s => s.Peek()).ToArray());
        }

        private List<Stack<char>> GetStacks(string[] input)
        {
            var stacks = new Stack<char>[9].ToList();

            foreach (var line in input.TakeWhile(i => i.Contains('[')).Reverse())
            {
                int stackNumber = 0;
                var crates = line.Chunk(4);

                foreach (var crate in crates)
                {
                    var c = crate[1];

                    if (c != ' ')
                    {
                        var stack = stacks[stackNumber];

                        if (stack == null)
                            stacks[stackNumber] = new Stack<char>();

                        stacks[stackNumber].Push(c);
                    }

                    stackNumber++;
                }
            }

            return stacks;
        }

        private List<(int numberOfCrates, int from, int to)> GetMoves(string[] input)
        {
            var moves = new List<(int numberOfCrates, int from, int to)>();

            foreach (var line in input.SkipWhile(l => !l.Contains("move")))
            {
                var sc = line.Replace("move", String.Empty).Replace("from", String.Empty).Replace("to", String.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

                moves.Add(new (sc[0], sc[1], sc[2]));
            }

            return moves;
        }
    }
}
