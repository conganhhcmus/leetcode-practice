public class Solution
{
    long INF = long.MaxValue / 2;
    public long MinCost(string s, int encCost, int flatCost)
    {
        int n = s.Length;
        return MinCost(0, n - 1, s, encCost, flatCost);
    }

    long MinCost(int st, int ed, string s, int encCost, int flatCost)
    {
        int len = ed - st + 1;
        if (len == 1) return s[st] == '0' ? flatCost : encCost;
        if (len <= 0) return INF;
        long ans = INF;
        long count = 0;
        for (int i = st; i <= ed; i++)
        {
            count += s[i] - '0';
        }
        if (count > 0)
        {
            ans = Math.Min(ans, count * len * encCost);
        }
        else
        {
            ans = Math.Min(ans, flatCost);
        }
        if (len % 2 == 0)
        {
            int mid = len / 2;
            ans = Math.Min(ans, MinCost(st, st + mid - 1, s, encCost, flatCost) + MinCost(st + mid, ed, s, encCost, flatCost));
        }

        return ans;
    }
}