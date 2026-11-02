public class Solution
{
    public int MinMoves2(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = CountMoves(nums[n / 2]);
        if (n % 2 == 0)
        {
            ans = Math.Min(ans, CountMoves(nums[(n + 1) / 2]));
        }
        return ans;

        int CountMoves(int x)
        {
            int ans = 0;
            foreach (int num in nums)
            {
                ans += Math.Abs(num - x);
            }
            return ans;
        }
    }
}