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
        // 01
        // 10
        // => swap them or 2 flips
        // 00
        // 11
        // => 10
        //    01
        // => cross swap + swap or 2 flips
        long costPair = Math.Min(2L * flipCost, swapCost);
        long pairs = Math.Min(a, b);
        long costPair2 = Math.Min(2L * flipCost, crossCost + swapCost);
        long pair2 = Math.Abs(a - b) / 2;
        long remain = Math.Abs(a - b) - 2 * pair2;
        return costPair * pairs + costPair2 * pair2 + remain * flipCost;
    }
}
