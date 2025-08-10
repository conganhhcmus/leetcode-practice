#if DEBUG
namespace Problems_869_2;
#endif

public class Solution
{
    public bool ReorderedPowerOf2(int n)
    {
        int[] countN = GetCount(n);
        for (int i = 0; i < 31; i++)
        {
            if (Equal(countN, GetCount(1 << i))) return true;
        }
        return false;
    }

    int[] GetCount(int num)
    {
        int[] count = new int[10];
        while (num > 0)
        {
            count[num % 10]++;
            num /= 10;
        }
        return count;
    }

    bool Equal(int[] a, int[] b)
    {
        for (int i = 0; i < 10; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}