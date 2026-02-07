public class Solution
{
    public int NextBeautifulNumber(int n)
    {
        int max = 1224444;
        for (int i = n + 1; i <= max; i++)
        {
            if (IsBalance(i)) return i;
        }
        return -1;
    }

    bool IsBalance(int n)
    {
        int[] count = new int[10];
        while (n > 0)
        {
            count[n % 10]++;
            n /= 10;
        }
        for (int i = 0; i < 10; i++)
        {
            if (count[i] > 0 && count[i] != i) return false;
        }

        return true;
    }
}