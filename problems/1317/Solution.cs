public class Solution
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (IsNoZeroNumber(i) && IsNoZeroNumber(n - i)) return [i, n - i];
        }

        return []; // not catch
    }

    bool IsNoZeroNumber(int n)
    {
        if (n <= 0) return false;
        while (n > 0)
        {
            if (n % 10 == 0) return false;
            n /= 10;
        }
        return true;
    }
}