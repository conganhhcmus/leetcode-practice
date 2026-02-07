public class Solution
{
    public int CountNumbersWithUniqueDigits(int n)
    {
        if (n == 0) return 1;
        if (n == 1) return 10;
        int ret = 10;
        int curr = 9;
        for (int i = 2; i <= n; i++)
        {
            curr *= 10 - (i - 1); // 10 ways [0...9] exclude i-1 first number. 0-th have 9 ways [1..9]
            ret += curr;
        }
        return ret;
    }
}