#if DEBUG
namespace Problems_2348_3;
#endif

public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        long ans = 0;
        int count = 0;
        foreach (int num in nums)
        {
            if (num == 0) count++;
            else
            {
                ans += 1L * count * (count + 1) / 2;
                count = 0;
            }
        }
        ans += 1L * count * (count + 1) / 2;
        return ans;
    }
}