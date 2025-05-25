#if DEBUG
namespace Weekly_450_Q3_2;
#endif

public class Solution
{
    public int MinMoves(string[] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        List<Pair>[] map = new List<Pair>[26];
        for (int i = 0; i < 26; i++)
        {
            map[i] = [];
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (char.IsLetter(matrix[i][j]))
                {
                    map[matrix[i][j] - 'A'].Add(new(i, j));
                }
            }
        }
        int[] dirs = [1, 0, -1, 0, 1];
        int moves = 0;
        Queue<Pair> queue = [];
        bool[,] visited = new bool[m, n];
        if (char.IsLetter(matrix[0][0]))
        {
            foreach (Pair next in map[matrix[0][0] - 'A'])
            {
                visited[next.Row, next.Col] = true;
                queue.Enqueue(next);
            }
        }
        else
        {
            visited[0, 0] = true;
            queue.Enqueue(new(0, 0));
        }
        while (queue.Count > 0)
        {
            for (int i = queue.Count; i > 0; i--)
            {
                Pair curr = queue.Dequeue();
                if (curr.Row == m - 1 && curr.Col == n - 1) return moves;

                for (int j = 0; j < 4; j++)
                {
                    Pair next = new(curr.Row + dirs[j], curr.Col + dirs[j + 1]);
                    if (IsValid(next, matrix, visited))
                    {
                        if (char.IsLetter(matrix[next.Row][next.Col]))
                        {
                            foreach (Pair next2 in map[matrix[next.Row][next.Col] - 'A'])
                            {
                                if (IsValid(next2, matrix, visited))
                                {
                                    visited[next2.Row, next2.Col] = true;
                                    queue.Enqueue(next2);
                                }
                            }
                        }
                        else
                        {
                            visited[next.Row, next.Col] = true;
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            moves++;
        }
        return -1;
    }

    bool IsValid(Pair next, string[] matrix, bool[,] visited)
    {
        int m = matrix.Length, n = matrix[0].Length;
        return next.Row >= 0 && next.Row < m && next.Col >= 0 && next.Col < n && matrix[next.Row][next.Col] != '#' && !visited[next.Row, next.Col];
    }

    public record Pair(int Row, int Col);
}