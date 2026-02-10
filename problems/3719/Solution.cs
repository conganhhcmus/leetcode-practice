public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            HashSet<int> evenCount = [];
            HashSet<int> oddCount = [];
            for (int j = i; j < n; j++)
            {
                if ((nums[j] & 1) != 0) oddCount.Add(nums[j]);
                else evenCount.Add(nums[j]);
                if (evenCount.Count == oddCount.Count)
                {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }
        return ans;
    }
}