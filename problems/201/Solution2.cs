#if DEBUG
namespace Problems_201_2;
#endif

public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        int count = 0;
        while (left != right)
        {
            left >>= 1;
            right >>= 1;
            count++;
        }
        return left << count;
    }
}