#if DEBUG
namespace Weekly_445_Q1;
#endif

public class Solution
{
    public int FindClosest(int x, int y, int z)
    {
        int diff1 = Math.Abs(x - z);
        int diff2 = Math.Abs(y - z);
        if (diff1 == diff2) return 0;
        if (diff1 > diff2) return 2;
        return 1;
    }
}