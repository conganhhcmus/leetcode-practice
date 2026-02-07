public class Solution
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        int n = nums.Count;
        int need = k - 1;
        if (need == 0) return true;
        for (int i = k + 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1] && nums[i - k] > nums[i - k - 1])
            {
                need--;
            }
            else
            {
                need = k - 1;
            }

            if (need == 0) return true;
        }
        return false;
    }
}