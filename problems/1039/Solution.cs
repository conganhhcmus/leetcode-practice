public class Solution
{
    Dictionary<int, int> memo = [];
    public int MinScoreTriangulation(int[] values)
    {
        return DP(0, values.Length - 1, values);
    }

    int DP(int i, int j, int[] values)
    {
        int n = values.Length;
        if (i + 2 > j) return 0;
        if (i + 2 == j) return values[i] * values[i + 1] * values[j];
        int key = i * n + j;
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = int.MaxValue;
        for (int k = i + 1; k < j; k++)
        {
            ans = Math.Min(ans, values[i] * values[j] * values[k] + DP(i, k, values) + DP(k, j, values));
        }
        return memo[key] = ans;
    }
}