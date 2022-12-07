using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AOC2022.Solvers
{
    public class Day7 : Solver
    {
        public override short Day { get; } = 7;

        public override object Solve1()
        {
            var input = GetInput().ToList();

            Directory tree = GetTree(input);

            return new[] { tree }.Flatten().Where(d => d.Size <= 100000).Sum(d => d.Size);
        }

        private static Directory GetTree(List<string> input)
        {
            Directory current = new Directory();

            foreach (var line in input)
            {
                if (line.Contains("$ cd"))
                {
                    if (line.Contains(".."))
                    {
                        current = current.Parent;
                    }
                    else if (line.Contains("/"))
                    {
                        while (current.Parent != null)
                        {
                            current = current.Parent;
                        }
                    }
                    else
                    {
                        var dirName = line.Split(' ').Last();
                        var subdir = current.Directories.FirstOrDefault(d => d.Name == dirName);
                        if (subdir == null)
                        {
                            var newDir = new Directory { Name = dirName, Parent = current };
                            current.Directories.Add(newDir);

                            current = newDir;
                        }
                    }
                }
                else if (char.IsNumber(line[0]))
                {
                    current.Files.Add(line.Split(' ')[1], int.Parse(line.Split(' ')[0]));
                }
            }

            while (current.Parent != null)
                current = current.Parent;
            return current;
        }

        public override object Solve2()
        {
            var input = GetInput().ToList();

            Directory tree = GetTree(input);

            var spaceLeft = 70000000 - tree.Size;
            var spaceRequired = 30000000 - spaceLeft;

            return new[] { tree }.Flatten().Where(f => f.Size > spaceRequired).OrderBy(f => f.Size).First().Size;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<Directory> Flatten(this IEnumerable<Directory> e) =>
            e.SelectMany(c => c.Directories.Flatten()).Concat(e);
    }

    public class Directory
    {
        public string Name { get; set; }

        public int Size
        {
            get
            {
                return this.Directories.Sum(d => d.Size) + this.Files.Sum(f => f.Value);
            }
        } 

        public Directory? Parent { get; set; }

        public List<Directory> Directories { get; set; } = new List<Directory>();


        public Dictionary<string, int> Files = new Dictionary<string, int>();
    }
}
