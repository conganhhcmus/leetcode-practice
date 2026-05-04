public class Solution
{
    public void Rotate(int[][] mattrix)
    {
        int n = mattrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                (mattrix[i][j], mattrix[j][i]) = (mattrix[j][i], mattrix[i][j]);
            }
            Array.Reverse(mattrix[i]);
        }
    }
}
