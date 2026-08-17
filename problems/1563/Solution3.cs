public class Solution
{
    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[][] f = new int[n][];
        int[][] maxL = new int[n][];
        int[][] maxR = new int[n][];
        for (int i = 0; i < n; i++)
        {
            f[i] = new int[n];
            maxL[i] = new int[n];
            maxR[i] = new int[n];
        }
        for (int left = n - 1; left >= 0; left--)
        {
            maxL[left][left] = maxR[left][left] = stoneValue[left];
            int tot = stoneValue[left];
            int sumL = 0;
            int i = left - 1;
            for (int right = left + 1; right < n; right++)
            {
                tot += stoneValue[right];
                while (i + 1 < right && (sumL + stoneValue[i + 1]) * 2 <= tot)
                {
                    sumL += stoneValue[i + 1];
                    i++;
                }
                if (left <= i)
                {
                    f[left][right] = Math.Max(f[left][right], maxL[left][i]);
                }
                if (i + 1 < right)
                {
                    f[left][right] = Math.Max(f[left][right], maxR[i + 2][right]);
                }
                if (sumL * 2 == tot)
                {
                    f[left][right] = Math.Max(f[left][right], maxR[i + 1][right]);
                }
                maxL[left][right] = Math.Max(maxL[left][right - 1], tot + f[left][right]);
                maxR[left][right] = Math.Max(maxR[left + 1][right], tot + f[left][right]);
            }
        }
        return f[0][n - 1];
    }
}