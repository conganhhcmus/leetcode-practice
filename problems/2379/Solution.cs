#if DEBUG
namespace Problems_2379;
#endif

public class Solution
{
    public int MinimumRecolors(string blocks, int k)
    {
        int n = blocks.Length;
        int count = 0;
        for (int i = 0; i < k; i++)
        {
            if (blocks[i] == 'W') count++;
        }
        int ans = count;
        for (int i = k; i < n; i++)
        {
            if (blocks[i - k] == 'W') count--;
            if (blocks[i] == 'W') count++;
            ans = Math.Min(ans, count);
        }
        return ans;
    }
}