public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        int[] f = new int[rowIndex + 1];

        // f[0] = 1
        // f[i] = f[i-1] * (n-i+1)/i
        f[0] = 1;
        for (int i = 1; i <= rowIndex; i++)
        {
            f[i] = (int)(f[i - 1] * (rowIndex - i + 1L) / i);
        }

        return f;
    }
}