#if DEBUG
namespace Problems_2588_2;
#endif

public class Solution
{
    public long BeautifulSubarrays(int[] a)
    {
        int n = a.Length;
        long ret = 0;
        // xor of a[l..r] = 0
        // xor[r] ^ xor[l] == 0
        int[] xor = new int[n + 1];
        for (int i = 0; i < n; ++i)
        {
            xor[i + 1] = xor[i] ^ a[i];
        }
        int[] map = new int[1 << 21];
        for (int i = 0; i <= n; ++i)
        {
            ret += map[xor[i]];
            map[xor[i]]++;
        }
        return ret;
    }
}