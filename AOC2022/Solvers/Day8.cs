namespace AOC2022.Solvers
{
    public class Day8 : Solver
    {
        public override short Day { get; } = 8;

        public override object Solve1()
        {
            var forest = GetInput();
            
            List<string> forestWithVisibility = new List<string>();

            var forestWidth = forest.First().Length;
            var forestHeight = forest.Length;
            for (int y = 0; y < forest.Count(); y++)
            {
                char[] trees = new char[forestWidth];
                for (int x = 0; x < forestWidth; x++)
                {
                    if (y == 0 || y == forestHeight - 1)
                    {
                        trees[x] = 'X';
                    }
                    else if (x == 0 || x == forestWidth - 1)
                    {
                        trees[x] = 'X';
                    }
                    else
                    {
                        var treesAtLeft = forest.ElementAt(y).Take(x).Select(t => t - '0');
                        var treesAtRight = forest.ElementAt(y).Skip(x + 1).Select(t => t - '0');
                        var treesAtTop = forest.Select(i => i.ElementAt(x)).Take(y).Select(c => c - '0');
                        var treesAtBottom = forest.Select(i => i.ElementAt(x)).Skip(y + 1).Select(c => c - '0');

                        var current = forest.ElementAt(y)[x] - '0';
                        if (treesAtLeft.Max() < current || treesAtRight.Max() < current || treesAtTop.Max() < current || treesAtBottom.Max() < current)
                        {
                            trees[x] = 'X';
                        }
                        else
                        {
                            trees[x] = 'O';
                        }
                    }
                }

                forestWithVisibility.Add(new string(trees));
            }

            return forestWithVisibility.Select(o => o.Replace("O", String.Empty)).Sum(o => o.Length);
        }

        public override object Solve2()
        {
            var forest = GetInput();

            var viewIndexes = new List<List<int>>();

            var forestWidth = forest.First().Length;
            var forestHeight = forest.Length;

            for (int y = 0; y < forest.Count(); y++)
            {
                var forestViewIndexes = new List<int>();
                for (int x = 0; x < forestWidth; x++)
                {
                    var current = forest.ElementAt(y)[x] - '0';
                    var atLeft = GetViewingDistance(current, forest.ElementAt(y).Select(t => t - '0').Take(x).Reverse());
                    var atRight = GetViewingDistance(current, forest.ElementAt(y).Select(t => t - '0').Skip(x + 1));
                    var atTop = GetViewingDistance(current, forest.Select(i => i.ElementAt(x)).Take(y).Select(c => c - '0').Reverse());
                    var atBottom = GetViewingDistance(current, forest.Select(i => i.ElementAt(x)).Skip(y + 1).Select(c => c - '0'));

                    forestViewIndexes.Add(atLeft * atRight * atTop * atBottom);
                }

                viewIndexes.Add(forestViewIndexes);
            }

            return viewIndexes.SelectMany(o => o).Max();
        }

        private int GetViewingDistance(int min, IEnumerable<int> view)
        {
            for (int i = 0; i < view.Count(); i++)
            {
                if (min <= view.ElementAt(i))
                    return i + 1;
            }

            return view.Count();
        }
    }
}
