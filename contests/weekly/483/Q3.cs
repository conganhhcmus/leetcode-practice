public class Solution
{
    public long MinimumCost(string s, string t, int flipCost, int swapCost, int crossCost)
    {
        int n = s.Length;
        int a = 0; // 01
        int b = 0; // 10
        for (int i = 0; i < n; i++)
        {
            if (s[i] == t[i]) continue;
            if (s[i] == '0') a++;
            else b++;
        }
        long pairCost = Math.Min(swapCost, 2L * flipCost);
        long Cost(int x, int y) => 1L * Math.Min(x, y) * pairCost + 1L * Math.Abs(x - y) * flipCost;
        long ans = Cost(a, b);
        for (int i = 1; i <= a; i++)
        {
            ans = Math.Min(ans, Cost(a - i, b + i) + 1L * i * crossCost);
        }
        for (int i = 1; i <= b; i++)
        {
            ans = Math.Min(ans, Cost(a + i, b - i) + 1L * i * crossCost);
        }

        return ans;
    }
}
