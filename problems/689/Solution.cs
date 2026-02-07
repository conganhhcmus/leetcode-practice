public class Solution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        Span<int> dp = stackalloc int[n + 1];
        dp[0] = 0;
        for (int i = 0; i < n; i++) dp[i + 1] = nums[i] + dp[i];

        int[,] bestSum = new int[4, n + 1];
        int[,] bestIdx = new int[4, n + 1];
        for (int subArrayIdx = 1; subArrayIdx <= 3; subArrayIdx++)
        {
            for (int endIdx = k * subArrayIdx; endIdx <= n; endIdx++)
            {
                int currSum = dp[endIdx] - dp[endIdx - k] + bestSum[subArrayIdx - 1, endIdx - k];
                if (currSum > bestSum[subArrayIdx, endIdx - 1])
                {
                    bestSum[subArrayIdx, endIdx] = currSum;
                    bestIdx[subArrayIdx, endIdx] = endIdx - k;
                }
                else
                {
                    bestSum[subArrayIdx, endIdx] = bestSum[subArrayIdx, endIdx - 1];
                    bestIdx[subArrayIdx, endIdx] = bestIdx[subArrayIdx, endIdx - 1];
                }
            }
        }
        int[] result = new int[3];
        int currEnd = n;
        for (int currSubArrayIdx = 3; currSubArrayIdx >= 1; currSubArrayIdx--)
        {
            result[currSubArrayIdx - 1] = bestIdx[currSubArrayIdx, currEnd];
            currEnd = result[currSubArrayIdx - 1];
        }
        return result;
    }
}