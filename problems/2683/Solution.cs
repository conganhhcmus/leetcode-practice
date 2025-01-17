#if DEBUG
namespace Problems_2683;
#endif

public class Solution
{
    public bool DoesValidArrayExist(int[] derived)
    {
        // a[0] = b[0] ^ b[1], a[1] = b[1] ^ b[2], ... ,a[n] = b[n] ^ b[0];
        // => a[0] ^ a[1] ^ ... a[n]  = 0
        int xorAll = 0, n = derived.Length;
        for (int i = 0; i < n; ++i) xorAll ^= derived[i];
        return xorAll == 0;
    }
}