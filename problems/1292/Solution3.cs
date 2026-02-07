public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int m = mat.Length, n = mat[0].Length;
        int low = 0, high = Math.Min(m, n), ans = 0;
        int[,] P = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int v = mat[i][j];
                P[i + 1, j + 1] = v + P[i + 1, j] + P[i, j + 1] - P[i, j];
            }
        }
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (IsValid(mid, m, n, P, threshold))
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

    bool IsValid(int mid, int m, int n, int[,] P, int threshold)
    {
        for (int i = 0; i + mid <= m; i++)
        {
            for (int j = 0; j + mid <= n; j++)
            {
                int sum = P[i + mid, j + mid] - P[i, j + mid] - P[i + mid, j] + P[i, j];
                if (sum <= threshold) return true;
            }
        }

        return false;
    }
}