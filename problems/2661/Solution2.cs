public class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length, k = arr.Length;

        // O(n)
        int[] map = new int[k + 1];
        for (int i = 0; i < k; i++)
        {
            map[arr[i]] = i;
        }

        int ans = k;
        for (int row = 0; row < n; row++)
        {
            int max = 0;
            for (int col = 0; col < m; col++)
            {
                max = Math.Max(map[mat[row][col]], max);
            }
            ans = Math.Min(ans, max);
        }

        for (int col = 0; col < m; col++)
        {
            int max = 0;
            for (int row = 0; row < n; row++)
            {
                max = Math.Max(map[mat[row][col]], max);
            }
            ans = Math.Min(ans, max);
        }

        return ans;
    }
}