public class Solution
{
    public int DigitFrequencyScore(int n)
    {
        int[] cnt = new int[10];
        while (n > 0)
        {
            cnt[n % 10]++;
            n /= 10;
        }
        int ans = 0;
        for (int i = 1; i < 10; i++)
        {
            ans += i * cnt[i];
        }
        return ans;
    }
}
