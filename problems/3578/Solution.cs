#if DEBUG
namespace Problems_3578;
#endif

public class Solution
{
    public int CountPartitions(int[] nums, int k)
    {
        int mod = (int)1e9 + 7;
        int n = nums.Length;
        long[] dp = new long[n + 1];
        long[] prefix = new long[n + 1];
        dp[0] = 1;
        prefix[0] = 1;
        SortedSet<int> cnt = [];
        Dictionary<int, int> freq = [];
        for (int i = 0, j = 0; i < n; i++)
        {
            int num = nums[i];
            cnt.Add(num);
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;
            while (j < i && cnt.Max - cnt.Min > k)
            {
                int key = nums[j];
                freq[key]--;

                if (freq[key] == 0)
                {
                    freq.Remove(key);
                    cnt.Remove(key);
                }
                j++;
            }
            dp[i + 1] = j > 0 ? (prefix[i] - prefix[j - 1] + mod) % mod : prefix[i];
            prefix[i + 1] = (prefix[i] + dp[i + 1]) % mod;
        }

        return (int)dp[n];
    }
}