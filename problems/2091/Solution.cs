public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int n = nums.Length;
        int min = 0;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[min] > nums[i]) min = i;
            if (nums[max] < nums[i]) max = i;
        }
        int ans = n;
        int a = min, b = max;
        if (a > b) (a, b) = (b, a);
        ans = Math.Min(ans, b + 1); // keep [b+1..]
        ans = Math.Min(ans, n - a); // keep [..a-1]
        ans = Math.Min(ans, a + 1 + n - b); // keep [a+1..b-1]
        return ans;
    }
}
