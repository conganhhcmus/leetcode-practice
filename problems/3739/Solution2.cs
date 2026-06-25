public class Solution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        int n = nums.Length;
        // 2 * cnt[t] > len 
        // 2 * cnt[t] > cnt[t] + cnt[o] (t: target, o: other)
        // cnt[t] > cnt[o]
        // cnt[t] - cnt[o] > 0
        // S[i] = cnt[t] - cnt[o] ending at i
        // i..j = S[i+1] - S[j] > 0
        // at i count all j for S[j] < S[i+1]

        int[] freq = new int[2 * n + 1];
        int cnt = n;
        freq[cnt] = 1;
        long ans = 0L;
        long sum = 0L;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == target)
            {
                sum += freq[cnt];
                cnt++;
                freq[cnt]++;
            }
            else
            {
                cnt--;
                sum -= freq[cnt];
                freq[cnt]++;
            }
            ans += sum;
        }
        return ans;
    }
}
