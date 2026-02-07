public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, int> dict = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                if (i - dict[nums[i]] <= k)
                {
                    return true;
                }
            }
            dict[nums[i]] = i;
        }
        return false;
    }
}