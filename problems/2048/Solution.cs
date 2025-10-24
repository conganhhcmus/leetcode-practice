#if DEBUG
namespace Problems_2048;
#endif

public class Solution
{
    int ans = int.MaxValue;
    public int NextBeautifulNumber(int n)
    {
        int[] candidate = new int[10];
        for (int i = 1; i <= 6; i++) // max = 1224444 ~ 7 digits
        {
            candidate[i] = i;
        }

        BackTracking(n, 0, candidate);
        return ans;
    }

    void BackTracking(int n, int val, int[] candidate)
    {
        if (val > ans) return;
        if (Ok(n, val))
        {
            ans = Math.Min(ans, val);
            return;
        }
        for (int i = 1; i <= 6; i++)
        {
            if (candidate[i] <= 0) continue;
            candidate[i]--;
            BackTracking(n, 10 * val + i, candidate);
            candidate[i]++;
        }
    }

    bool Ok(int n, int val)
    {
        if (val <= n) return false;
        int[] freq = new int[10];
        while (val > 0)
        {
            freq[val % 10]++;
            val /= 10;
        }
        for (int i = 1; i < 10; i++)
        {
            if (freq[i] > 0 && freq[i] != i) return false;
        }
        return true;
    }
}