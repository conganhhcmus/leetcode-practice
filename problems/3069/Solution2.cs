public class Solution
{
    public int[] ResultArray(int[] nums)
    {
        int n = nums.Length;
        int idx1 = 0, idx2 = n - 1;
        int[] ans = new int[n];
        ans[idx1] = nums[0];
        ans[idx2] = nums[1];
        for (int i = 2; i < n; i++)
        {
            if (ans[idx1] > ans[idx2]) ans[++idx1] = nums[i];
            else ans[--idx2] = nums[i];
        }
        Array.Reverse(ans, idx2, n - idx2);
        return ans;
    }
}