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
        pq.Enqueue(new(0, 0), 0);
        int[] dirs = [1, 0, -1, 0, 1];
        while (pq.Count > 0)
        {
            Pair curr = pq.Dequeue();
            // update adjacent
            for (int d = 0; d < 4; d++)
            {
                int newR = curr.Row + dirs[d];
                int newC = curr.Col + dirs[d + 1];
                if (IsValid(newR, newC, n, m))
                {
                    int val = Math.Max(minTime[curr.Row][curr.Col], moveTime[newR][newC]) + 1;
                    if (val < minTime[newR][newC])
                    {
                        minTime[newR][newC] = val;
                        pq.Enqueue(new(newR, newC), val);
                    }
                }
            }
        }

        return minTime[n - 1][m - 1];
    }

    bool IsValid(int r, int c, int n, int m)
    {
        return r >= 0 && r < n && c >= 0 && c < m;
    }

    public record Pair(int Row, int Col);
}