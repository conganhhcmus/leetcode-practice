#if DEBUG
namespace Problems_1051;
#endif

public class Solution
{
    public int HeightChecker(int[] heights)
    {
        int n = heights.Length;
        int[] expected = new int[n];
        Array.Copy(heights, expected, n);
        bool hasSwap = true;
        while (hasSwap)
        {
            hasSwap = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (expected[i] > expected[i + 1])
                {
                    (expected[i], expected[i + 1]) = (expected[i + 1], expected[i]);
                    hasSwap = true;
                }
            }
        }

        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            if (heights[i] != expected[i]) ret++;
        }
        return ret;
    }
}