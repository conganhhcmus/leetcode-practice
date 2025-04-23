#if DEBUG
namespace Problems_1399;
#endif

public class Solution
{
    public int CountLargestGroup(int n)
    {
        int[] map = new int[37]; // 9*4 +1
        for (int i = 1; i <= n; i++)
        {
            int sum = SumOfDigit(i);
            map[sum]++;
        }

        int ret = 0, max = 0;
        foreach (int freq in map)
        {
            if (max < freq) max = freq;
        }

        foreach (int freq in map)
        {
            if (freq == max) ret++;
        }
        return ret;
    }

    int SumOfDigit(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }
}