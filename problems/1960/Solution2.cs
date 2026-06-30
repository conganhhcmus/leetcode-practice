public class Solution
{
    public long MaxProduct(string s)
    {
        int n = s.Length;
        int[] p = new int[n];
        for (int i = 0, c = 0, r = -1; i < n; i++)
        {
            int m = 2 * c - i;
            if (i < r) p[i] = Math.Min(p[m], r - i);
            while (i - p[i] - 1 >= 0
                && i + p[i] + 1 < n
                && s[i - p[i] - 1] == s[i + p[i] + 1]) p[i]++;
            if (i + p[i] > r)
            {
                c = i;
                r = i + p[i];
            }
        }
        long ans = 0L;
        long leftBest = 0;
        int[] rightBest = new int[n];
        Queue<int[]> q = [];
        for (int i = n - 1; i >= 0; i--)
        {
            while (q.Count > 0 && q.Peek()[0] - q.Peek()[1] > i) q.Dequeue();
            rightBest[i] = 1 + (q.Count == 0 ? 0 : (q.Peek()[0] - i) * 2);
            q.Enqueue([i, p[i]]);
        }
        q = [];
        for (int i = 0; i < n - 1; i++)
        {
            while (q.Count > 0 && q.Peek()[0] + q.Peek()[1] < i) q.Dequeue();
            leftBest = Math.Max(leftBest, 1 + (q.Count == 0 ? 0 : (i - q.Peek()[0]) * 2));
            ans = Math.Max(ans, 1L * leftBest * rightBest[i + 1]);
            q.Enqueue([i, p[i]]);
        }
        return ans;
    }
}
