#if DEBUG
namespace Problems_717_3;
#endif

public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        int n = bits.Length;
        int i = n - 2;
        while (i >= 0 && bits[i] > 0)
        {
            i--;
        }
        // 0 1 2 [3] 4 5 6 7 8 
        // 1 1 1 [0] 1 1 1 1 0
        return (n - i - 2) % 2 == 0;
    }
}