public class Solution
{
    public string SmallestNumber(string num, long t)
    {
        int n = num.Length;
        if (!Factor(t, out int need2, out int need3, out int need5, out int need7)) return "-1";
        (int p2, int p3, int p5, int p7)[] cost = {
            (0,0,0,0), //0 (unused)
            (0,0,0,0), //1
            (1,0,0,0), //2
            (0,1,0,0), //3
            (2,0,0,0), //4
            (0,0,1,0), //5
            (1,1,0,0), //6
            (0,0,0,1), //7
            (3,0,0,0), //8
            (0,2,0,0), //9
        };
        Dictionary<(int, int, int, int, int, bool), bool> memo = [];
        char[] ans = new char[n];
        int len = n;
        bool ok = Dfs(0, need2, need3, need5, need7, true);
        if (ok) return new(ans);
        while (len < n + 100)
        {
            len++;
            memo.Clear();
            ans = new char[len];
            ok = Dfs(0, need2, need3, need5, need7, false);
            if (ok) return new(ans);
        }
        return "-1";

        bool Dfs(int pos, int need2, int need3, int need5, int need7, bool limit)
        {
            need2 = Math.Max(0, need2);
            need3 = Math.Max(0, need3);
            need5 = Math.Max(0, need5);
            need7 = Math.Max(0, need7);
            if (pos >= len) return need2 == 0 && need3 == 0 && need5 == 0 && need7 == 0;
            var key = (pos, need2, need3, need5, need7, limit);
            if (!CanFill(len - pos, need2, need3, need5, need7)) return memo[key] = false;
            if (memo.TryGetValue(key, out bool cache)) return cache;
            int start = limit ? num[pos] - '0' : 1;
            for (int d = Math.Max(1, start); d <= 9; d++)
            {
                var (p2, p3, p5, p7) = cost[d];
                if (Dfs(pos + 1, need2 - p2, need3 - p3, need5 - p5, need7 - p7, limit & d == start))
                {
                    ans[pos] = (char)(d + '0');
                    return memo[key] = true;
                }
            }
            return memo[key] = false;
        }

        bool CanFill(int remain, int need2, int need3, int need5, int need7)
        {
            if (need2 > remain * 3) return false;
            if (need3 > remain * 2) return false;
            if (need5 > remain) return false;
            if (need7 > remain) return false;
            return true;
        }

        bool Factor(long t, out int c2, out int c3, out int c5, out int c7)
        {
            c2 = c3 = c5 = c7 = 0;
            while (t % 2 == 0) { c2++; t /= 2; }
            while (t % 3 == 0) { c3++; t /= 3; }
            while (t % 5 == 0) { c5++; t /= 5; }
            while (t % 7 == 0) { c7++; t /= 7; }
            return t == 1;
        }
    }
}
