public class Solution
{
    public bool WinnerSquareGame(int n)
    {
        Dictionary<int, bool> memo = [];
        return DP(0);
        bool DP(int pos)
        {
            if (pos >= n) return false;
            if (memo.TryGetValue(pos, out bool cache)) return cache;
            for (int i = 1; i * i + pos <= n; i++)
            {
                if (!DP(pos + i * i)) return memo[pos] = true;
            }

            return memo[pos] = false;
        }
    }
}
