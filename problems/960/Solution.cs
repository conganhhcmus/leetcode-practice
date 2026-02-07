public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        return DP(0, -1, strs);
    }

    Dictionary<(int, int), int> memo = [];

    int DP(int pos, int prev, string[] strs)
    {
        int n = strs.Length, m = strs[0].Length;
        if (pos >= m) return 0;
        var key = (pos, prev);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = int.MaxValue;
        // check each row
        bool isCorrect = true;
        for (int i = 0; i < n; i++)
        {
            if (prev >= 0 && strs[i][pos] < strs[i][prev])
            {
                isCorrect = false;
                break;
            }
        }
        if (isCorrect)
        {
            ans = Math.Min(DP(pos + 1, prev, strs) + 1, DP(pos + 1, pos, strs));
        }
        else
        {
            ans = DP(pos + 1, prev, strs) + 1;
        }

        return memo[key] = ans;
    }
}