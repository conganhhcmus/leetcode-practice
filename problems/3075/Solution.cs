#if DEBUG
namespace Problems_3075;
#endif

public class Solution
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness, (a, b) => b - a);
        long ans = 0;
        for (int i = 0; i < k; i++)
        {
            ans += Math.Max(0, happiness[i] - i);
        }
        return ans;
    }
}