namespace Problem_1975;

public class Solution
{
    public static void Execute()
    {
        int[][] matrix = [[10, -6, -6, -8], [-3, -7, -8, -9], [-4, -8, -5, -8], [-9, -9, -6, -8]];
        var solution = new Solution();
        Console.WriteLine(solution.MaxMatrixSum(matrix));
    }
    public long MaxMatrixSum(int[][] matrix)
    {
        int n = matrix.Length;
        long result = 0;
        int negativeCount = 0;
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int val = Math.Abs(matrix[i][j]);
                result += val;
                min = Math.Min(min, val);
                if (matrix[i][j] < 0) negativeCount++;
            }
        }

        return result - negativeCount % 2 * min * 2;
    }
}