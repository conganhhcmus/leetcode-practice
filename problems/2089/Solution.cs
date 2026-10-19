public class Solution
{
    public IList<int> TargetIndices(int[] nums, int target)
    {
        Array.Sort(nums);
        List<int> ans = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target) ans.Add(i);
        }
        return ans;
    }
}