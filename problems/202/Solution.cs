#if DEBUG
namespace Problems_202;
#endif

public class Solution
{
    public bool IsHappy(int n)
    {
        if (n <= 1) return true;
        HashSet<int> memo = [];
        memo.Add(n);
        while (n != 1)
        {
            n = GetNext(n);
            if (memo.Contains(n)) return false;
            memo.Add(n);
        }

        return true;
    }

    private int GetNext(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }

        return sum;
    }
}