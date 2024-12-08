#if DEBUG
namespace Problems_190;
#endif

public class Solution
{
    public uint reverseBits(uint n)
    {
        uint ans = 0;
        bool[] bits = new bool[32];
        int idx = 0;
        while (n > 0)
        {
            bits[idx] = (n & 1) == 1;
            n >>= 1;
            idx++;
        }
        for (int i = 0; i < bits.Length; i++)
        {
            ans = (ans << 1) + (bits[i] ? (uint)1 : 0);
        }
        return ans;
    }
}