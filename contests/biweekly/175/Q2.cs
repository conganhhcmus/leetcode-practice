public class Solution
{
    public int MinimumK(int[] nums)
    {
        int n = nums.Length;
        int max = int.MaxValue / 2;
        int l = 1, r = max + 1, ans = max + 1;
        bool Ok(int k)
        {
            long c = 0;
            for (int i = 0; i < n; i++)
            {
                c += (nums[i] + k - 1) / k;
            }
            return c <= 1L * k * k;
        }

        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (Ok(m))
            {
                ans = m;
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        return ans;
    }
}
