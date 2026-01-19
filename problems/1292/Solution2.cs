#if DEBUG
namespace Problems_1292_2;
#endif

public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int m = mat.Length, n = mat[0].Length;
        int[,] rowSum = new int[m, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int v = mat[i][j];
                rowSum[i, j + 1] = rowSum[i, j] + v;
            }
        }
        int high = Math.Min(n, m), low = 0, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (IsValid(m, n, mid, rowSum, threshold))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }

        }
        return ans;
    }

    bool IsValid(int m, int n, int k, int[,] rowSum, int threshold)
    {
        for (int r = 0; r + k <= m; r++)
        {
            for (int c = 0; c + k <= n; c++)
            {
                int sum = 0;
                for (int i = r; i < r + k; i++)
                {
                    sum += rowSum[i, c + k] - rowSum[i, c];
                }

                if (sum <= threshold) return true;
            }
        }

        return false;
    }
}