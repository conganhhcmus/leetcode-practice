public class Solution
{
    public int TotalMoney(int n)
    {
        int ans = 0;
        int cur = 0;
        // full week = 28
        for (int i = 0; i < n / 7; i++)
        {
            ans += 28 + cur;
            cur += 7;
        }

        // remain
        cur /= 7;
        for (int i = 0; i < n % 7; i++)
        {
            ans += cur + i + 1;
        }
        return ans;
    }
}