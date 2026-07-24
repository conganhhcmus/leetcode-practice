public class Solution
{
    public long NumGoodSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<long, long> cnt = [];
        cnt[0] = 1;
        long sum = 0;
        foreach (int x in nums)
        {
            sum += x;
            sum %= k;
            cnt[sum] = cnt.GetValueOrDefault(sum, 0) + 1;
        }
        long ans = 0;
        foreach (long val in cnt.Values)
        {
            ans += val * (val - 1) / 2;
        }
        for (int i = 0; i < n;)
        {
            int j = i;
            while (j < n && nums[i] == nums[j]) j++;
            int q = j - i;
            int v = nums[i];
            int g = GCD(v, k);
            int step = k / g;
            for (int L = step; L <= q; L += step)
            {
                ans -= q - L;
            }
            i = j;
        }
        return ans;

        int GCD(int a, int b)
        {
            while (b > 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }
    }
}
