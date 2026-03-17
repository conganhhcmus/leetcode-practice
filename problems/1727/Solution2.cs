public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        List<int[]> prevHeight = [];
        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            List<int[]> height = [];
            bool[] seen = new bool[n];
            foreach (int[] e in prevHeight)
            {
                int h = e[0], c = e[1];
                if (matrix[i][c] == 1)
                {
                    height.Add([h + 1, c]);
                    seen[c] = true;
                }
            }
            for (int j = 0; j < n; j++)
            {
                if (seen[j] == false && matrix[i][j] == 1)
                {
                    height.Add([1, j]);
                }
            }
            for (int j = 0; j < height.Count; j++)
            {
                int h = height[j][0];
                ans = Math.Max(ans, h * (j + 1));
            }
            prevHeight = height;
        }
        return ans;
    }
}