public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int n = nums.Length;
        int[] prefixCount = new int[n + 1];
        for (int i = 1; i <= n; ++i)
        {
            prefixCount[i] = prefixCount[i - 1] + (1 - nums[i - 1]);
        }
        int low = 0, high = n, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(prefixCount, mid, k))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }

    bool Ok(int[] prefixCount, int len, int k)
    {
        int n = prefixCount.Length;
        for (int i = len; i < n; i++)
        {
            if (prefixCount[i] - prefixCount[i - len] <= k) return true;
        }
        return false;
    }
}