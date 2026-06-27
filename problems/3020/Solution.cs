public class Solution
{
    public int MaximumLength(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> cnt = [];
        for (int i = 0; i < n; i++) cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) + 1;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            if (x == 1)
            {
                int val = 2 * ((cnt[x] - 1) / 2) + 1;
                if (ans < val) ans = val;
                continue;
            }
            int len = 1;
            while (true)
            {
                int sqrtX = (int)Math.Sqrt(x);
                if (sqrtX * sqrtX != x || cnt.GetValueOrDefault(sqrtX, 0) < 2) break;
                len += 2;
                x = sqrtX;
            }
            if (ans < len) ans = len;
        }
        return ans;
    }
}
