#if DEBUG
namespace Contests_434_Q3;
#endif

public class Solution
{
    public int MaxFrequency(int[] nums, int k)
    {
        int countK = 0;
        foreach (int num in nums)
        {
            if (num == k) countK++;
        }
        int ans = 0;
        for (int i = 1; i < 51; i++)
        {
            ans = Math.Max(ans, Kadane(nums, k, i));
        }

        return countK + ans;
    }

    private int Kadane(int[] nums, int k, int n)
    {
        int res = 0, cur = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == n) cur++;
            if (nums[i] == k) cur--;
            if (cur < 0) cur = 0;
            res = Math.Max(res, cur);
        }

        return res;
    }
}