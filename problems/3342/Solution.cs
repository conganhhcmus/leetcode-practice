#if DEBUG
using System.Runtime.Intrinsics.Arm;

#endif

public class Solution
{
    public int MinTimeToReach(int[][] moveTime)
    {
        int n = moveTime.Length, m = moveTime[0].Length;
        int[][] minTime = new int[n][];
        for (int i = 0; i < n; i++)
        {
            minTime[i] = new int[m];
            Array.Fill(minTime[i], int.MaxValue);
        }

        minTime[0][0] = 0;
        PriorityQueue<Pair, int> pq = new();
        pq.Enqueue(new(0, 0, 1), 0);
        int[] dirs = [1, 0, -1, 0, 1];
        while (pq.Count > 0)
        {
            Pair curr = pq.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int newR = curr.Row + dirs[i];
                int newC = curr.Col + dirs[i + 1];
                int newAdjust = curr.Adjust ^ 1 ^ 2;
                if (IsValid(newR, newC, n, m))
                {
                    int val = Math.Max(minTime[curr.Row][curr.Col], moveTime[newR][newC]) + curr.Adjust;
                    if (val < minTime[newR][newC])
                    {
                        minTime[newR][newC] = val;
                        pq.Enqueue(new(newR, newC, newAdjust), val);
                    }
                }
            }
        }

        return minTime[n - 1][m - 1];
    }

    public record Pair(int Row, int Col, int Adjust);

    bool IsValid(int r, int c, int n, int m)
    {
        return r >= 0 && r < n && c >= 0 && c < m;
    }
}