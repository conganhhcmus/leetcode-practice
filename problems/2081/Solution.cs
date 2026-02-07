public class Solution
{
    public long KMirror(int k, int n)
    {
        int left = 1, count = 0;
        long ans = 0;
        while (count < n)
        {
            int right = left * 10;
            for (int op = 0; op < 2; ++op)
            {
                // op = 0 (odd), op = 1 (even)
                for (int i = left; i < right && count < n; ++i)
                {
                    long combined = i;
                    int x = (op == 0 ? i / 10 : i);
                    while (x > 0)
                    {
                        combined = combined * 10 + x % 10;
                        x /= 10;
                    }
                    if (IsPalindrome(combined, k))
                    {
                        ++count;
                        ans += combined;
                    }
                }
            }
            left = right;
        }
        return ans;
    }

    bool IsPalindrome(long num, int k)
    {
        StringBuilder sb = new();
        while (num > 0)
        {
            sb.Append(num % k);
            num /= k;
        }

        for (int i = 0; i < sb.Length / 2; i++)
        {
            if (sb[i] != sb[sb.Length - i - 1]) return false;
        }
        return true;
    }
}