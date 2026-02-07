public class Solution
{
    public int[][] GenerateMatrix(int n)
    {
        int[][] ret = new int[n][];
        for (int i = 0; i < n; i++)
        {
            ret[i] = new int[n];
        }
        int minR = 0, maxR = n - 1, minC = 0, maxC = n - 1;
        int val = 1;
        while (minR <= maxR && minC <= maxC)
        {
            // left -> right
            for (int i = minC; i <= maxC; i++)
            {
                ret[minR][i] = val++;
            }
            minR++;
            // top -> bottom
            for (int i = minR; i <= maxR; i++)
            {
                ret[i][maxC] = val++;
            }
            maxC--;
            // right -> left
            for (int i = maxC; i >= minC; i--)
            {
                ret[maxR][i] = val++;
            }
            maxR--;
            // bottom -> top
            for (int i = maxR; i >= minR; i--)
            {
                ret[i][minC] = val++;
            }
            minC++;
        }
        return ret;
    }
}