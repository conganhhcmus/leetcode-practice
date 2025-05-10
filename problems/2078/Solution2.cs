#if DEBUG
namespace Problems_2078_2;
#endif

public class Solution
{
    public int MaxDistance(int[] colors)
    {
        int n = colors.Length;
        int ret = 0;
        int i = 0;
        while (i < n && colors[i] == colors[n - 1]) i++;
        ret = Math.Max(ret, n - 1 - i);
        i = n - 1;
        while (i >= 0 && colors[i] == colors[0]) i--;
        ret = Math.Max(ret, i);
        return ret;
    }
}