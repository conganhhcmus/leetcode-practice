public class Solution
{
    public int SumCounts(IList<int> nums)
    {
        int n = nums.Count;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            HashSet<int> seen = [];
            for (int j = i; j < n; j++)
            {
                seen.Add(nums[j]);
                ans += seen.Count * seen.Count;
            }
        }
        return ans;
    }
}