public class Solution
{
    public long ElevatorRequests(int n, int start, int[] requests)
    {
        List<int> left = [];
        List<int> right = [];
        foreach (int r in requests)
        {
            if (r < start) left.Add(r);
            else if (r > start) right.Add(r);
        }

        left.Sort((a, b) => b.CompareTo(a));
        right.Sort();
        long INF = 1L << 60;
        long[][] dpL = new long[left.Count + 1][];
        long[][] dpR = new long[left.Count + 1][];
        for (int i = 0; i <= left.Count; i++)
        {
            dpL[i] = new long[right.Count + 1];
            Array.Fill(dpL[i], INF);
            dpR[i] = new long[right.Count + 1];
            Array.Fill(dpR[i], INF);
        }

        dpL[0][0] = 0;
        dpR[0][0] = 0;
        for (int i = 0; i <= left.Count; i++)
        {
            for (int j = 0; j <= right.Count; j++)
            {
                int cnt = left.Count + right.Count - i - j;
                int curL = (i > 0) ? left[i - 1] : start;
                int curR = (j > 0) ? right[j - 1] : start;
                if (i < left.Count)
                {
                    // can move left
                    long dL = Math.Abs(left[i] - curL);
                    dpL[i + 1][j] = Math.Min(dpL[i + 1][j], dpL[i][j] + dL * cnt);

                    long dR = Math.Abs(left[i] - curR);
                    dpL[i + 1][j] = Math.Min(dpL[i + 1][j], dpR[i][j] + dR * cnt);
                }

                if (j < right.Count)
                {
                    // can move right
                    long dL = Math.Abs(right[j] - curL);
                    dpR[i][j + 1] = Math.Min(dpR[i][j + 1], dpL[i][j] + dL * cnt);

                    long dR = Math.Abs(right[j] - curR);
                    dpR[i][j + 1] = Math.Min(dpR[i][j + 1], dpR[i][j] + dR * cnt);
                }
            }
        }

        return Math.Min(dpL[^1][^1], dpR[^1][^1]);
    }
}