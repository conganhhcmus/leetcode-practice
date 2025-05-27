#if DEBUG
namespace Problems_2894_2;
#endif

public class Solution
{
    public int DifferenceOfSums(int n, int m)
    {
        int tot = n * (n + 1) / 2;
        int cnt = n / m;
        return tot - (cnt * (cnt + 1) * m);
    }
}