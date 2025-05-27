#if DEBUG
namespace Problems_2894_2;
#endif

public class Solution
{
    public int DifferenceOfSums(int n, int m)
    {
        int sum = n * (n + 1) / 2;
        if (m == 1) return -sum;
        for (int i = m; i <= n; i += m)
        {
            sum -= 2 * i;
        }
        return sum;
    }
}