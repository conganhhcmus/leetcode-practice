#if DEBUG
namespace Problems_2094_3;
#endif

public class Solution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        List<int> ret = [];
        int[] count = new int[10];
        foreach (int d in digits)
        {
            count[d]++;
        }

        for (int num = 100; num < 1000; num += 2)
        {
            int ones = num % 10;
            int tens = (num / 10) % 10;
            int hund = num / 100;
            count[ones]--;
            count[tens]--;
            count[hund]--;
            if (count[ones] >= 0 && count[tens] >= 0 && count[hund] >= 0)
            {
                ret.Add(num);
            }
            count[ones]++;
            count[tens]++;
            count[hund]++;
        }

        return [.. ret];
    }
}