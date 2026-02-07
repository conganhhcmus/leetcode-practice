public class Solution
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        int ans = 0;
        int maxLen = fruits[^1][0] + 1;
        int[] prefixSum = new int[maxLen];
        foreach (int[] fruit in fruits)
        {
            prefixSum[fruit[0]] += fruit[1];
        }
        for (int i = 1; i < maxLen; i++)
        {
            prefixSum[i] += prefixSum[i - 1];
        }

        // fixed left
        for (int i = 0; i <= startPos; i++)
        {
            int left = startPos - i;
            int right = startPos + (k - 2 * i);
            if (k - 2 * i < 0) break;
            int leftVal = left <= 0 ? 0 : prefixSum[Math.Min(left - 1, maxLen - 1)];
            int rightVal = prefixSum[Math.Min(right, maxLen - 1)];
            int val = rightVal - leftVal;
            ans = Math.Max(ans, val);
        }

        // fixed right
        for (int i = 0; i < maxLen; i++)
        {
            int right = startPos + i;
            int left = startPos - (k - 2 * i);
            if (k - 2 * i < 0) break;
            int leftVal = left <= 0 ? 0 : prefixSum[Math.Min(left - 1, maxLen - 1)];
            int rightVal = prefixSum[Math.Min(right, maxLen - 1)];
            int val = rightVal - leftVal;
            ans = Math.Max(ans, val);
        }

        return ans;
    }
}