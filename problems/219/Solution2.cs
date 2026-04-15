public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        int n = nums.Length;
        HashSet<int> set = [];
        for (int i = 0; i < n; i++)
        {
            if (set.Contains(nums[i]))
                return true;
            set.Add(nums[i]);
            if (i >= k)
            {
                set.Remove(nums[i - k]);
            }
        }
        return false;
    }
}
