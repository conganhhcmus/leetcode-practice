public class Solution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        int n = differences.Length;
        long min = 0, max = 0, curr = 0;
        for (int i = 0; i < n; i++)
        {
            curr += differences[i];
            if (min > curr) min = curr;
            if (max < curr) max = curr;
        }
        long ret = (upper - lower) - (max - min) + 1;
        if (ret < 0) return 0;
        return (int)ret;
    }
}