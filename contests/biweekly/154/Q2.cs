#if DEBUG
namespace Biweekly_154_Q2;
#endif

public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        int n = nums.Length;
        if (n < 3) return n;
        int count = 0;
        while (n > 0)
        {
            n >>= 1;
            count++;
        }
        return 1 << count;
    }
}