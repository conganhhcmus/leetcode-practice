public class Solution
{
    public bool HasSameDigits(string s)
    {
        int n = s.Length;
        int[] param = BuildParam(n - 2);
        int sum1 = 0, sum2 = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            sum1 = (sum1 + param[i] * (s[i] - '0')) % 10;
            sum2 = (sum2 + param[i] * (s[i + 1] - '0')) % 10;
        }

        return sum1 == sum2;
    }

    private int ModInverse(int a, int m)
    {
        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1)
            {
                return x;
            }
        }
        return 1;
    }

    private int CountFactor(int n, int p)
    {
        int cnt = 0;
        while (n % p == 0 && n != 0)
        {
            cnt++;
            n /= p;
        }
        return cnt;
    }

    private int FastPower(int a, int b)
    {
        int result = 1;
        while (b > 0)
        {
            if ((b & 1) != 0) result *= a;
            a *= a;
            b >>= 1;
        }
        return result;
    }

    private int[] BuildParam(int m)
    {
        int[] coeff = new int[m + 1];
        coeff[0] = 1;
        int currentVal = 1;
        int currentE2 = 0;
        int currentE5 = 0;

        int[] cycle2 = [2, 4, 8, 6];

        for (int i = 1; i <= m; i++)
        {
            // Q3_1.png
            int numerator = m - i + 1;
            int denominator = i;

            int num2 = CountFactor(numerator, 2);
            int num5 = CountFactor(numerator, 5);
            int den2 = CountFactor(denominator, 2);
            int den5 = CountFactor(denominator, 5);

            currentE2 += num2 - den2;
            currentE5 += num5 - den5;

            int numeratorPart = numerator / (FastPower(2, num2) * FastPower(5, num5));
            int denominatorPart = denominator / (FastPower(2, den2) * FastPower(5, den5));

            int inv = ModInverse(denominatorPart, 10);
            currentVal = (currentVal * numeratorPart * inv) % 10;

            int power2 = (currentE2 == 0) ? 1 : cycle2[(currentE2 - 1) % 4];
            int power5 = (currentE5 > 0) ? 5 : 1;

            coeff[i] = (currentVal * power2 * power5) % 10;
        }

        return coeff;
    }
}