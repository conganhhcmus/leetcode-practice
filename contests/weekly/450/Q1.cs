#if DEBUG
namespace Weekly_450_Q1;
#endif

public class Solution
{
    public int SmallestIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (SumDigit(nums[i]) == i) return i;
        }
        return -1;
    }
    int SumDigit(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}