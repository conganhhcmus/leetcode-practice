public class Solution
{
    public bool WinnerSquareGame(int n)
    {
        Dictionary<(int, int), bool> memo = [];
        return DP(0, 1);
        bool DP(int pos, int turn)
        {
            if (pos >= n) return turn < 0;
            var key = (pos, turn);
            if (memo.TryGetValue(key, out bool cache)) return cache;

            if (turn > 0)
            {
                for (int i = 1; i * i + pos <= n; i++)
                {
                    if (DP(pos + i * i, -turn)) return memo[key] = true;
                }
                return memo[key] = false;
            }
            else
            {
                for (int i = 1; i * i + pos <= n; i++)
                {
                    if (!DP(pos + i * i, -turn)) return memo[key] = false;
                }
                return memo[key] = true;
            }
        }
    }
}
