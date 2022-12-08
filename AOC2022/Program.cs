using System.Diagnostics;
using AOC2022;
using McMaster.Extensions.CommandLineUtils;
internal class Program
{
    private static readonly IEnumerable<Solver> solvers;

    [Option(Description = "Day to solve")]
    public static int? Day { get; } = 8;

    static Program()
    {
        var type = typeof(Solver);
        solvers = AppDomain.CurrentDomain.GetAssemblies()
                                         .SelectMany(s => s.GetTypes())
                                         .Where(p => type.IsAssignableFrom(p))
                                         .Where(p => !p.IsAbstract)
                                         .Select(t => Activator.CreateInstance(t))
                                         .Cast<Solver>();
    }

    public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

    private void OnExecute()
    {
        foreach (var solver in solvers.Where(s => !Day.HasValue || s.Day == Day))
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Solution day {solver.Day}: Puzzle 1 {solver.Solve1()}, Puzzle 2 {solver.Solve2()}");
            stopwatch.Stop();
            Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}