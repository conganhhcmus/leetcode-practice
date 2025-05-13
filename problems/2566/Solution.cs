#if DEBUG
namespace Problems_2566;
#endif

public class Solution
{
    public int MinMaxDifference(int num)
    {
        List<int> digits = [];
        while (num > 0)
        {
            digits.Add(num % 10);
            num /= 10;
        }

        int n = digits.Count;
        int maxRemapIdx = n;
        int minRemapIdx = n;
        for (int i = n - 1; i >= 0; i--)
        {
            if (maxRemapIdx == n && digits[i] != 9)
            {
                maxRemapIdx = i;
            }
            if (minRemapIdx == n && digits[i] != 0)
            {
                minRemapIdx = i;
            }
        }
        if (maxRemapIdx == n) maxRemapIdx--;
        if (minRemapIdx == n) minRemapIdx--;
        int min = 0, max = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] == digits[maxRemapIdx])
            {
                max = max * 10 + 9;
            }
            else
            {
                max = max * 10 + digits[i];
            }

            if (digits[i] == digits[minRemapIdx])
            {
                min = min * 10 + 0;
            }
            else
            {
                min = min * 10 + digits[i];
            }
        }
        return max - min;
    }
}