using System.Text;
using System.Text.RegularExpressions;

namespace Problem_773;
public class Solution
{
    public static void Execute()
    {
        int[][] board = [[4, 1, 2], [5, 0, 3]];
        var solution = new Solution();
        Console.WriteLine(solution.SlidingPuzzle(board));
    }
    public int SlidingPuzzle(int[][] board)
    {
        var target = "123450";
        var start = "";

        for (var i = 0; i < 2; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                start += board[i][j].ToString();
            }
        }

        if (start == target) return 0;

        int[][] moves = [
            [1, 3],
            [0, 2, 4],
            [1, 5],
            [0, 4],
            [1, 3, 5],
            [2, 4]
        ];

        var queue = new Queue<(string, int)>();
        var visited = new HashSet<string>();

        queue.Enqueue((start, 0));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();
            var zeroIndex = current.IndexOf('0');

            if (current == target)
            {
                return steps;
            }

            foreach (var move in moves[zeroIndex])
            {
                var newConfig = Swap(current, zeroIndex, move);

                if (visited.Add(newConfig))
                {
                    queue.Enqueue((newConfig, steps + 1));
                }
            }
        }

        return -1;
    }

    private string Swap(string s, int i, int j)
    {
        var arr = s.ToCharArray();
        (arr[i], arr[j]) = (arr[j], arr[i]);
        return new string(arr);
    }
}