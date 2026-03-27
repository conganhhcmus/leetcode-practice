public class Solution
{
    public bool IsDigitorialPermutation(int n)
    {
        int[] fact = new int[10];
        fact[0] = 1;
        for (int i = 1; i < 10; i++)
        {
            fact[i] = fact[i - 1] * i;
        }
        int[] count = new int[10];
        while (n > 0)
        {
            count[n % 10]++;
            n /= 10;
        }

        long sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += count[i] * fact[i];
        }

        while (sum > 0)
        {
            count[sum % 10]--;
            sum /= 10;
        }
        for (int i = 0; i < 10; i++)
        {
            if (count[i] != 0) return false;
        }
        return true;
    }
}