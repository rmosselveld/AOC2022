using System.Reflection;

namespace AOC
{
    public abstract class Solver
    {
        public abstract short Day { get; }

        public abstract object Solve1();

        public abstract object Solve2();

        protected string[] GetInput()
        {
            try
            {
                return File.ReadAllLines($"Inputs\\{Day}.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Input file for day {Day} not found");
                return Array.Empty<string>();
            }
        }
    }
}
