public class Solution
{
    public int MinAbsoluteDifference(int[] nums)
    {
        int n = nums.Length;
        int ans = int.MaxValue;
        int p1 = -1, p2 = -1;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 1)
            {
                p1 = i;
                if (p2 != -1) ans = Math.Min(ans, Math.Abs(p1 - p2));
            }
            else if (nums[i] == 2)
            {
                p2 = i;
                if (p1 != -1) ans = Math.Min(ans, Math.Abs(p2 - p1));
            }
        }
        if (ans == int.MaxValue) return -1;
        return ans;
    }
}