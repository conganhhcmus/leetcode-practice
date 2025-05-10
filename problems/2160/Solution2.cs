#if DEBUG
namespace Problems_2160_2;
#endif

public class Solution
{
    public int MinimumSum(int num)
    {
        int min1 = 10, min2 = 10, sum = 0;
        while (num > 0)
        {
            int digit = num % 10;
            if (min1 >= digit)
            {
                min2 = min1;
                min1 = digit;
            }
            else if (min2 >= digit)
            {
                min2 = digit;
            }
            sum += digit;
            num /= 10;
        }
        return sum + (min1 + min2) * 9;
    }
}