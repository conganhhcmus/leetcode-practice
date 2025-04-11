#if DEBUG
namespace Problems_2843;
#endif

public class Solution
{
    public int CountSymmetricIntegers(int low, int high)
    {
        int count = 0;
        for (int i = low; i <= high; i++)
        {
            if (IsSymmetric(i)) count++;
        }
        return count;
    }

    bool IsSymmetric(int num)
    {
        string numStr = num.ToString();
        int n = numStr.Length;
        if (n % 2 != 0) return false;
        int diff = 0;
        for (int i = 0; i < n / 2; i++)
        {
            diff += numStr[i] - numStr[n / 2 + i];
        }

        return diff == 0;
    }
}