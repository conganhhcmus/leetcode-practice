#if DEBUG
namespace Problems_2210;
#endif

public class Solution
{
    public int CountHillValley(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] == nums[i - 1]) continue;
            int before = i, after = i;
            while (before >= 0 && nums[i] == nums[before]) before--;
            while (after < n && nums[i] == nums[after]) after++;
            if (before < 0 || after >= n) continue;
            if (nums[before] > nums[i] && nums[after] > nums[i]) count++;
            if (nums[before] < nums[i] && nums[after] < nums[i]) count++;
        }
        return count;
    }
}