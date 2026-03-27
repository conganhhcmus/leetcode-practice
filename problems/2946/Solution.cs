public class Solution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        int m = mat.Length, n = mat[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i % 2 == 0)
                {
                    // shift right
                    if (mat[i][j] != mat[i][Mod(j + k, n)]) return false;
                }
                else
                {
                    // shift left
                    if (mat[i][j] != mat[i][Mod(j - k, n)]) return false;
                }
            }
        }
        return true;
    }

    int Mod(int a, int b) => (a % b + b) % b;
}