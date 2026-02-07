public class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length, k = arr.Length;

        // O(n)
        (int x, int y)[] map = new (int x, int y)[k + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                map[mat[i][j]] = (i, j);
            }
        }

        int[] countR = new int[n];
        int[] countC = new int[m];
        for (int i = 0; i < k; i++)
        {
            var (r, c) = map[arr[i]];
            countR[r]++;
            countC[c]++;
            if (countC[c] == n || countR[r] == m) return i;
        }
        return k;
    }
}