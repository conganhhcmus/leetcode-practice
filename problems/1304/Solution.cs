#if DEBUG
namespace Problems_1304;
#endif

public class Solution
{
    public int[] SumZero(int n)
    {
        int[] ans = new int[n];
        ans[n - 1] = 0;
        for (int i = 1; i < n; i += 2)
        {
            ans[i] = i;
            ans[i - 1] = -i;
        }
        return ans;
    }
}