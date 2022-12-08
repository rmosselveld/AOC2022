namespace AOC2022.Solvers;

public class Day8 : Solver
{
    public override short Day { get; } = 8;

    public override object Solve1()
    {
        var forest = GetInput().Select(i => i.ToArray().Select(c => c - '0').ToArray()).ToArray();

        List<string> forestWithVisibility = new List<string>();

        var forestWidth = forest.First().Length;
        var forestHeight = forest.Length;
        int score = 0;
        for (int y = 0; y < forest.Count(); y++)
        {
            for (int x = 0; x < forestWidth; x++)
            {
                if (y == 0 || y == forestHeight - 1 || x == 0 || x == forestWidth - 1)
                {
                    score++;
                }
                else
                {
                    var treesAtLeft = forest[y][0..x];
                    var treesAtRight = forest[y][(x + 1)..];
                    var treesAtTop = forest.Select(i => i[x]).Take(y);
                    var treesAtBottom = forest.Select(i => i[x]).Skip(y + 1);

                    var current = forest[y][x];
                    if (treesAtLeft.Max() < current || treesAtRight.Max() < current || treesAtTop.Max() < current || treesAtBottom.Max() < current)
                    {
                        score++;
                    }
                }
            }
        }

        return score;
    }

    public override object Solve2()
    {
        var forest = GetInput().Select(i => i.ToArray().Select(c => c - '0').ToArray()).ToArray();

        var viewIndexes = new List<List<int>>();

        var forestWidth = forest.First().Length;
        var forestHeight = forest.Length;

        for (int y = 0; y < forest.Count(); y++)
        {
            var forestViewIndexes = new List<int>();
            for (int x = 0; x < forestWidth; x++)
            {
                var current = forest.ElementAt(y)[x];
                var atLeft = GetViewingDistance(current, forest[y].Take(x).Reverse());
                var atRight = GetViewingDistance(current, forest[y][(x + 1)..]);
                var atTop = GetViewingDistance(current, forest.Select(i => i[x]).Take(y).Reverse());
                var atBottom = GetViewingDistance(current, forest.Select(i => i[x]).Skip(y + 1));

                forestViewIndexes.Add(atLeft * atRight * atTop * atBottom);
            }

            viewIndexes.Add(forestViewIndexes);
        }

        return viewIndexes.SelectMany(o => o).Max();
    }

    private int GetViewingDistance(int min, IEnumerable<int> view)
    {
        return view.TakeWhile(i => i < min).Count() + 1;
    }
}
