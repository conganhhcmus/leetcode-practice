public class Solution
{
    public int FindMaxVal(int n, int[][] restrictions, int[] diff)
    {
        int INF = 1 << 30;
        int[] mx = new int[n];
        Array.Fill(mx, INF);
        mx[0] = 0;
        foreach (int[] val in restrictions)
        {
            mx[val[0]] = Math.Min(mx[val[0]], val[1]);
        }

        for (int i = 0; i < n - 1; i++)
        {
            mx[i + 1] = Math.Min(mx[i + 1], mx[i] + diff[i]);
        }

        for (int i = n - 2; i >= 0; i--)
        {
            mx[i] = Math.Min(mx[i], mx[i + 1] + diff[i]);
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (ans < mx[i]) ans = mx[i];
        }
        return ans;
    }
}
