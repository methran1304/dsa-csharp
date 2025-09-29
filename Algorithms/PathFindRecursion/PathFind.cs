using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithms;

public static class PathFind
{
    private static readonly List<List<char>> Map =
    [
        ['S', ' ', '#', '#'],
        [' ', '#', '#', '#'],
        [' ', ' ', '#', 'E'],
        ['#', ' ', '#', ' '],
        ['#', ' ', '#', ' '],
        ['#', ' ', ' ', ' '],
        [' ', ' ', ' ', ' ']
    ];

    private static readonly List<List<bool>> Visited = Enumerable
        .Range(0, 7)
        .Select(_ => Enumerable.Repeat(false, 4).ToList())
        .ToList();
        
    public static readonly List<((int, int), string)> Path = [];

    private static bool SolveRecurse(List<List<char>> m, int r, int c, string dir = "")
    {
        // check boundaries
        if (r < 0 || c < 0 || r > m.Count - 1 || c > m[0].Count - 1) return false;

        // check if wall
        if (m[r][c] == '#') return false;
        
        // check if end
        if (m[r][c] == 'E')
        {
            Path.Add(((r, c), dir));
            return true;
        }

        // check if visited
        if (Visited[r][c]) return false;
        Visited[r][c] = true;

        bool found =
            SolveRecurse(m, r, c - 1, "left")  ||   // left 
            SolveRecurse(m, r, c + 1, "right") ||   // right
            SolveRecurse(m, r - 1, c, "up")    ||   // up
            SolveRecurse(m, r + 1, c, "down");      // down

        if (found)
            Path.Add(((r, c), dir)); // add traversed path if end is found

        return found;
    }

    public static void Begin()
    {
        bool found = SolveRecurse(Map, 0, 0, "START");

        if (found)
        {
            Path.Reverse();
            foreach (((int r, int c), string dir) in Path)
            {
                Console.WriteLine($"{r}, {c} - {dir}");
            }
        }
    }
}
