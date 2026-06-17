public class Solution
{
    public bool CompletePrime(int num)
    {
        if (!IsPrime(num)) return false;
        string str = num.ToString();
        int n = str.Length;
        int pref = 0;
        for (int i = 0; i < n - 1; i++)
        {
            pref = pref * 10 + (str[i] - '0');
            if (!IsPrime(pref)) return false;
        }
        int suff = 0;
        int b = 1;
        for (int i = n - 1; i > 0; i--)
        {
            suff += (str[i] - '0') * b;
            b *= 10;
            if (!IsPrime(suff)) return false;
        }
        return true;
        bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
