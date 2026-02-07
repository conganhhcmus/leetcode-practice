public class Solution
{
    public int MaxDistance(int[] colors)
    {
        int n = colors.Length;
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            int last = i;
            for (int j = i; j < n; j++)
            {
                if (colors[j] != colors[i]) last = j;
            }
            ret = Math.Max(ret, last - i);
        }
        return ret;
    }
}