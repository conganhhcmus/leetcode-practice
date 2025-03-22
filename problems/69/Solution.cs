#if DEBUG
namespace Problems_69;
#endif

public class Solution
{
    public int MySqrt(int x)
    {
        if (x == 0 || x == 1) return x;
        int left = 1, right = x;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if ((x / mid) < mid)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return right;
    }
}