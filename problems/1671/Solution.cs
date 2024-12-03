namespace Problem_1671;

public class Solution
{
    public int MinimumMountainRemovals(int[] nums)
    {
        int max = 0;
        int[] dpLIS = new int[nums.Length];
        int[] dpLDS = new int[nums.Length];

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j] && dpLIS[i] < dpLIS[j] + 1) dpLIS[i] = dpLIS[j] + 1;
            }
        }

        for (int i = 1; i < nums.Length; i++)
        {
            dpLIS[i] = Math.Max(dpLIS[i], dpLIS[i - 1]);
        }

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[^(i + 1)] > nums[^(j + 1)] && dpLDS[i] < dpLDS[j] + 1) dpLDS[i] = dpLDS[j] + 1;
            }
        }

        for (int i = 1; i < nums.Length; i++)
        {
            dpLDS[i] = Math.Max(dpLDS[i], dpLDS[i - 1]);
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (dpLDS[^(i + 1)] > 0 && dpLIS[i] > 0)
            {
                max = Math.Max(max, dpLDS[^(i + 1)] + dpLIS[i]);
            }
        }

        return nums.Length - max - 1;
    }
}