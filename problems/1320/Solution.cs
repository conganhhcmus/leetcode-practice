public class Solution
{
    public int MinimumDistance(string word)
    {
        int n = word.Length;
        int INF = int.MaxValue / 2;

        int Dist(int a, int b)
        {
            if (a == -1) return 0;
            int x1 = a / 6, y1 = a % 6;
            int x2 = b / 6, y2 = b % 6;
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        Dictionary<(int, int), int> memo = [];

        int DP(int pos, int free)
        {
            if (pos == n) return 0;

            var key = (pos, free);
            if (memo.TryGetValue(key, out int val)) return val;

            int curr = word[pos] - 'A';
            int prev = word[pos - 1] - 'A';

            // 1. use same finger (move prev → curr)
            int ans = Dist(prev, curr) + DP(pos + 1, free);

            // 2. use free finger
            ans = Math.Min(ans, Dist(free, curr) + DP(pos + 1, prev));

            return memo[key] = ans;
        }

        // Start from pos = 1 (first char already typed)
        return DP(1, -1);
    }
}