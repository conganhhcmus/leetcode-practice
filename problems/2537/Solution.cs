#if DEBUG
namespace Problems_2537;
#endif

public class Solution
{
    public long CountGood(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<int, int> map = [];
        long ret = 0;
        int left = 0;
        long currPair = 0;
        for (int right = 0; right < n; right++)
        {
            map.TryAdd(nums[right], 0);
            if (map[nums[right]] > 0) currPair += map[nums[right]];
            map[nums[right]]++;

            while (left <= right && currPair >= k)
            {
                ret += n - right;
                // increase left
                map[nums[left]]--;
                currPair -= map[nums[left]];
                left++;
            }
        }
        return ret;
    }
}