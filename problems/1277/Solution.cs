namespace Problem_1277;

public class Solution
{
    public int CountSquares(int[][] matrix)
    {
        return CountSquares_DP(matrix);
        //return CountSquares_Loop(matrix);
    }

    public int CountSquares_DP(int[][] matrix)
    {
        int ans = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 1 && i > 0 && j > 0)
                {
                    matrix[i][j] += Math.Min(matrix[i - 1][j], Math.Min(matrix[i][j - 1], matrix[i - 1][j - 1]));
                }
                ans += matrix[i][j];
            }
        }
        return ans;
    }

    public int CountSquares_Loop(int[][] matrix)
    {
        int ans = 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0) continue;
                ans++;
                bool isContinue = true;
                int len = 2;
                while (isContinue && (i + len) <= m && (j + len) <= n)
                {
                    isContinue = IsSquare(matrix, i, j, len);
                    ans += isContinue ? 1 : 0;
                    len++;
                }
            }
        }
        return ans;
    }

    private bool IsSquare(int[][] matrix, int i, int j, int len)
    {
        for (int k = i; k < i + len; k++)
        {
            if (matrix[k][j + len - 1] == 0) return false;
        }

        for (int k = j; k < j + len; k++)
        {
            if (matrix[i + len - 1][k] == 0) return false;
        }

        return true;
    }
}