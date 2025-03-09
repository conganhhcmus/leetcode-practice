#if DEBUG
namespace Problems_3208;
#endif

public class Solution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int n = colors.Length;
        int[] newColors = new int[n + k];
        for (int i = 0; i < n + k; i++)
        {
            newColors[i] = colors[i % n];
        }
        int count = 0;
        int left = 0, right = 0;
        while (right < n + k)
        {
            if (right - left < k - 1)
            {
                int prev = right;
                right++;
                if (right == n + k - 1) break;
                if (newColors[right] == newColors[prev]) left = prev + 1;
                continue;
            }

            if (right - left == k - 1) count++;
            left++;
        }
        return count;
    }
}