#if DEBUG
namespace Problems_2654;
#endif

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int min = int.MaxValue;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 1) count++;
            int gcd = nums[i];
            for (int j = i + 1; j < n; j++)
            {
                gcd = GCD(gcd, nums[j]);
                if (gcd == 1)
                {
                    min = Math.Min(min, j - i);
                    break;
                }
            }
        }
        if (count > 0) return n - count;
        if (min == int.MaxValue) return -1;
        return n + min - 1;
    }

    int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}