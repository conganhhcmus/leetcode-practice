public class Solution
{
    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[] prefix = new int[n + 1];
        for (int i = 0; i < n; i++) prefix[i + 1] = prefix[i] + stoneValue[i];
        int[,] memo = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                memo[i, j] = -1;
            }
        }

        return DP(0, n - 1);

        int DP(int left, int right)
        {
            if (left >= right) return 0;
            if (memo[left, right] != -1) return memo[left, right];
            int ans = 0;
            for (int i = left; i < right; i++)
            {
                int sumL = prefix[i + 1] - prefix[left];
                int sumR = prefix[right + 1] - prefix[i + 1];

                // [left, i] vs [i+1, right]
                if (sumL >= sumR)
                {
                    ans = Math.Max(ans, sumR + DP(i + 1, right));
                }
                if (sumL <= sumR)
                {
                    ans = Math.Max(ans, sumL + DP(left, i));
                }
            }

            return memo[left, right] = ans;
        }
    }
}
