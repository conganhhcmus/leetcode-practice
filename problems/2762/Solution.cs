public class Solution
{
    public long ContinuousSubarrays(int[] nums)
    {
        int left = 0, right = 0, n = nums.Length;
        long ans = 0;
        SortedDictionary<int, int> map = [];
        while (right < n)
        {
            map[nums[right]] = map.GetValueOrDefault(nums[right], 0) + 1;
            while (map.Last().Key - map.First().Key > 2)
            {
                map[nums[left]]--;
                if (map[nums[left]] == 0)
                {
                    map.Remove(nums[left]);
                }
                left++;
            }

            ans += right - left + 1;
            right++;
        }
        return ans;
    }
}