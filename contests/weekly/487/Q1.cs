#if DEBUG
namespace Weekly_487_Q1;
#endif

public class Solution
{
    public int CountMonobit(int n)
    {
        int ans = 1;
        for (int i = 1; i <= n; i = (i << 1) | 1)
        {
            ans++;
        }
        return ans;
    }
}