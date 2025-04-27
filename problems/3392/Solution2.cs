#if DEBUG
namespace Problems_3392_2;
#endif

public class Solution
{
    public int CountSubarrays(int[] a)
    {
        int n = a.Length;
        int count = 0;
        int l = 0;
        for (int r = 2; r < n; ++r, ++l)
        {
            int mid = (r + l) >> 1;
            if (a[mid] == 2 * (a[l] + a[r])) count++;
        }
        return count;
    }
}