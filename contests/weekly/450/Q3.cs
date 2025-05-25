#if DEBUG
namespace Weekly_450_Q3;
#endif

public class Solution
{
    public int MinMoves(string[] matrix)
    {
        // n x m = 10^6
        int m = matrix.Length, n = matrix[0].Length;
        List<int[]>[] map = new List<int[]>[26];
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
                    map[matrix[i][j] - 'A'].Add([i, j]);
                }
            }
        }
        int[] dirs = [1, 0, -1, 0, 1];
        int[,] distance = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                distance[i, j] = int.MaxValue;
            }
        }
        LinkedList<int[]> dequeue = new();
        dequeue.AddFirst([0, 0]);
        distance[0, 0] = 0;
        int[] distance2 = new int[26];
        Array.Fill(distance2, int.MaxValue);
        while (dequeue.Count > 0)
        {
            int[] curr = dequeue.First.Value;
            dequeue.RemoveFirst();
            if (curr.Length == 2)
            {
                int r = curr[0], c = curr[1];
                if (char.IsLetter(matrix[r][c]))
                {
                    int id = matrix[r][c] - 'A';
                    if (distance2[id] > distance[r, c])
                    {
                        distance2[id] = distance[r, c];
                        dequeue.AddFirst([id]);
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    int[] next = [r + dirs[i], c + dirs[i + 1]];
                    if (IsValid(next, matrix))
                    {
                        int val = distance[r, c];
                        if (val + 1 < distance[next[0], next[1]])
                        {
                            distance[next[0], next[1]] = val + 1;
                            dequeue.AddLast(next);
                        }
                    }
                }
            }
            else
            {
                int id = curr[0];
                foreach (int[] next in map[id])
                {
                    int r = next[0], c = next[1];
                    if (distance[r, c] > distance2[id])
                    {
                        distance[r, c] = distance2[id];
                        dequeue.AddFirst([r, c]);
                    }
                }
            }

        }
        if (distance[m - 1, n - 1] == int.MaxValue) return -1;
        return distance[m - 1, n - 1];
    }

    bool IsValid(int[] next, string[] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        return next[0] >= 0 && next[0] < m && next[1] >= 0 && next[1] < n && matrix[next[0]][next[1]] != '#';
    }
}