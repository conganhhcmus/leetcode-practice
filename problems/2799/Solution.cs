public class Solution
{
    public int CountCompleteSubarrays(int[] nums)
    {
        HashSet<int> set = [.. nums];
        int distinct = set.Count;
        Dictionary<int, int> map = [];
        int ret = 0;
        int n = nums.Length;
        int left = 0;
        for (int right = 0; right < n; right++)
        {
            map.TryAdd(nums[right], 0);
            map[nums[right]]++;
            while (left <= right && map.Keys.Count == distinct)
            {
                ret += n - right;
                if (map[nums[left]] == 1)
                {
                    map.Remove(nums[left]);
                }
                else
                {
                    map[nums[left]]--;
                }
                left++;
            }
        }
        return ret;
    }
}