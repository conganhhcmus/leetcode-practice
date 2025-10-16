#if DEBUG
namespace Problems_3350_2;
#endif

public class Solution
{
    public int MaxIncreasingSubarrays(IList<int> nums)
    {
        int n = nums.Count;
        int count = 1, preCount = 0;
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                count++;
            }
            else
            {
                preCount = count;
                count = 1;
            }

            ans = Math.Max(ans, count / 2);
            ans = Math.Max(ans, Math.Min(preCount, count));
        }
        return ans;
    }
}