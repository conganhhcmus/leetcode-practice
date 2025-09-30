#if DEBUG
namespace Problems_2221_2;
#endif

public class Solution
{
    public int TriangularSum(int[] nums)
    {
        int n = nums.Length;
        int m = n - 1;
        int mod = 10;

        int ans = 0;
        int pow2 = 0, pow5 = 0, comb = 1;
        int[] inv = [0, 1, 0, 7, 0, 0, 0, 3, 0, 9];
        int[] pow2Mod10 = [6, 2, 4, 8];
        for (int i = 0; i < n; i++)
        {
            if (pow2 == 0 || pow5 == 0)
            {
                int coeff = pow2 > 0 ? comb * pow2Mod10[pow2 % 4] : pow5 > 0 ? comb * 5 : comb;
                ans = (ans + nums[i] * coeff) % mod;
            }
            if (i == m) break;
            int mul = n - 1 - i;
            while (mul % 2 == 0)
            {
                mul /= 2;
                pow2++;
            }

            while (mul % 5 == 0)
            {
                mul /= 5;
                pow5++;
            }
            comb = comb * mul % mod;

            int div = i + 1;
            while (div % 2 == 0)
            {
                div /= 2;
                pow2--;
            }
            while (div % 5 == 0)
            {
                div /= 5;
                pow5--;
            }
            comb = comb * inv[div % mod] % mod;
        }

        return ans;
    }
}