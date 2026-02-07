public class Solution
{
    public int SumOfFlooredPairs(int[] nums)
    {
        int mod = 1000000007;
        int maxVal = 0;
        foreach (int num in nums)
        {
            maxVal = Math.Max(maxVal, num);
        }
        long ans = 0;
        int[] freq = new int[maxVal + 1];
        foreach (int num in nums)
        {
            freq[num]++;
        }
        int[] prefixSums = new int[maxVal + 1];
        for (int i = 1; i < maxVal + 1; i++)
        {
            prefixSums[i] = prefixSums[i - 1] + freq[i];
        }

        for (int i = 1; i <= maxVal; i++)
        {
            if (freq[i] == 0) continue;
            for (int k = 1; (k * i) <= maxVal; k++)
            {
                int lo = (i * k) - 1;
                int hi = Math.Min(maxVal, (k + 1) * i - 1); // [i*k, i*(k+1) -1]
                int count = prefixSums[hi] - prefixSums[lo];
                ans = (ans + 1L * freq[i] * k * count) % mod;
            }
        }

        return (int)ans;
    }
}