public class Solution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        for (int i = 0; i < 4; i++)
        {
            Rotate(mat);
            if (IsSame(mat, target)) return true;
        }
        return false;
    }

    void Rotate(int[][] mat)
    {
        int n = mat.Length;
        // transpose
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                (mat[i][j], mat[j][i]) = (mat[j][i], mat[i][j]);
            }
        }

        // reverse
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                (mat[i][j], mat[i][n - 1 - j]) = (mat[i][n - 1 - j], mat[i][j]);
            }
        }
    }

    bool IsSame(int[][] mat, int[][] tar)
    {
        int n = mat.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] != tar[i][j]) return false;
            }
        }
        return true;
    }
}