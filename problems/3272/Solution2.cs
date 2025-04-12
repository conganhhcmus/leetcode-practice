#if DEBUG
namespace Problems_3272_2;
#endif

public class Solution
{
    public long CountGoodIntegers(int n, int k)
    {
        HashSet<string> set = [];
        int min = (int)Math.Pow(10, (n - 1) / 2);
        int max = (int)Math.Pow(10, (n + 1) / 2);
        for (int i = min; i < max; i++)
        {
            string s = i.ToString();
            for (int j = n - s.Length - 1; j >= 0; j--)
            {
                s += s[j];
            }
            long num = long.Parse(s);
            if (num % k == 0)
            {
                char[] tmp = s.ToCharArray();
                Array.Sort(tmp);
                set.Add(new(tmp));
            }
        }
        long[] fact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = fact[i - 1] * i;
        }
        long ret = 0;
        foreach (string s in set)
        {
            int[] cnt = new int[10];
            foreach (char c in s)
            {
                cnt[c - '0']++;
            }
            long tot = (n - cnt[0]) * fact[n - 1];
            foreach (int x in cnt)
            {
                tot /= fact[x];
            }

            ret += tot;
        }

        return ret;
    }
}