public class Solution
{
    public int[] LimitOccurrences(int[] nums, int k)
    {
        int n = nums.Length;
        int count = 1;
        List<int> ans = [nums[0]];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count <= k) ans.Add(nums[i]);
        }
        return ans.ToArray();
    }
}
