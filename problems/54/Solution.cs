#if DEBUG
namespace Problems_54;
#endif

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        IList<int> result = [];
        int top = 0, bottom = matrix.Length - 1, left = 0, right = matrix[0].Length - 1;
        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++) result.Add(matrix[top][i]);
            top++;

            for (int i = top; i <= bottom; i++) result.Add(matrix[i][right]);
            right--;

            if (bottom >= top)
            {
                for (int i = right; i >= left; i--) result.Add(matrix[bottom][i]);
                bottom--;
            }

            if (right >= left)
            {
                for (int i = bottom; i >= top; i--) result.Add(matrix[i][left]);
                left++;
            }
        }

        return result;
    }
}