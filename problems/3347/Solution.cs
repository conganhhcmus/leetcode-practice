#if DEBUG
namespace Problems_3347;
#endif

public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        int n = nums.Length;
        Dictionary<int, int> count = [];
        int ans = 0, i = 0, j = 0;
        // case 1: [num-k, num+k]
        foreach (int num in nums)
        {
            while (j < n && nums[j] <= num + k)
            {
                count[nums[j]] = count.GetValueOrDefault(nums[j], 0) + 1;
                j++;
            }

            while (i < n && nums[i] < num - k)
            {
                count[nums[i]] = count.GetValueOrDefault(nums[i], 0) - 1;
                i++;
            }

            ans = Math.Max(ans, Math.Min(j - i, numOperations + count.GetValueOrDefault(num, 0)));
        }

        // case 2: [num, num+2k]
        i = 0;
        j = 0;
        while (j < n)
        {
            while (i < n && nums[j] - nums[i] > 2 * k)
            {
                i++;
            }
            ans = Math.Max(ans, Math.Min(j - i + 1, numOperations));
            j++;
        }

        return ans;
    }
}