public class Solution
{
    public int MaxSum(IList<int> nums, int k)
    {
        int n = nums.Count;
        int[] cnt = new int[30];
        foreach (int num in nums)
        {
            for (int i = 0; i < 30; i++)
            {
                if ((num & (1 << i)) != 0) cnt[i]++;
            }
        }
        int mod = (int)1e9 + 7;
        long ans = 0;
        for (int i = 0; i < k; i++)
        {
            int val = 0;
            for (int j = 29; j >= 0; j--)
            {
                if (cnt[j] > 0)
                {
                    val |= 1 << j;
                    cnt[j]--;
                }
            }
            ans = (ans + 1L * val * val) % mod;
        }

        return (int)ans;
    }
}
