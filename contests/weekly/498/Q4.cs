public class Solution
{
    public long CountGoodIntegersOnPath(long l, long r, string directions)
    {
        HashSet<int> mark = [];
        int row = 0, col = 0;
        mark.Add(0);
        foreach (char d in directions)
        {
            if (d == 'D') row++;
            else col++;
            mark.Add(row * 4 + col);
        }
        return Count(r, mark) - Count(l - 1, mark);
    }
    Dictionary<(int, int, bool), long> memo = [];

    long Count(long n, HashSet<int> mark)
    {
        memo = [];
        string str = n.ToString().PadLeft(16, '0');
        return DP(0, 0, true, str, mark);
    }

    long DP(int pos, int min, bool tight, string str, HashSet<int> mark)
    {
        int n = str.Length;
        if (pos >= n) return 1L;
        var key = (pos, min, tight);
        if (memo.TryGetValue(key, out long cache)) return cache;
        long ans = 0L;
        int digit = str[pos] - '0';
        int r = tight ? digit : 9;
        int l = mark.Contains(pos) ? min : 0;
        for (int d = l; d <= r; d++)
        {
            bool newTight = tight & (d == digit);
            int newMin = mark.Contains(pos) ? d : min;
            ans += DP(pos + 1, newMin, newTight, str, mark);
        }

        return memo[key] = ans;
    }
}
