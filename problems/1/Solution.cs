#if DEBUG
namespace Problems_1;
#endif

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int n = nums.Length;
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++)
        {
            int comp = target - nums[i];
            if (map.ContainsKey(comp)) return [map[comp], i];
            map[nums[i]] = i;
        }
        return [];
    }
}