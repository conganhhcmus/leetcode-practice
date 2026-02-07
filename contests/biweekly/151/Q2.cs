public class Solution
{
    public int CountArrays(int[] original, int[][] bounds)
    {
        int low = int.MinValue, high = int.MaxValue;
        int n = original.Length;
        for (int i = 0; i < n; i++)
        {
            low = Math.Max(low, bounds[i][0] - original[i]);
            high = Math.Min(high, bounds[i][1] - original[i]);
        }
        if (high < low) return 0;
        return high - low + 1;
    }
}