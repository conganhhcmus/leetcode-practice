public class Solution
{
    public int StoneGameVIII(int[] stones)
    {
        int n = stones.Length;
        int[] prefix = new int[n + 1];
        for (int i = 0; i < n; i++) prefix[i + 1] = prefix[i] + stones[i];

        Dictionary<int, int> memo = [];

        return DP(2);

        int DP(int i)
        {
            if (i >= n) return prefix[n];
            if (memo.TryGetValue(i, out int cache)) return cache;
            return memo[i] = Math.Max(DP(i + 1), prefix[i] - DP(i + 1));
        }
    }
}