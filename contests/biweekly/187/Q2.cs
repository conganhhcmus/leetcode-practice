public class Solution
{
    public long MaximumValue(int n, int s, int m)
    {
        // s[0] = s
        // s[1]: s + m
        // s[2]: s + m - 1
        // s[3]: s + 2*m -1
        // s[4]: s + 2*m - 2
        // .. s[n-1]:
        // s[0] = s
        // s[1] = s - 1
        // s[2] = s + m - 1
        // s[3] = s + m - 2
        // s[4] = s + 2 * m - 2
        // s[n-1]:
        if (n == 1) return s;
        int p = n / 2;
        return 1L * s + 1L * p * m - p + 1;
    }
}
