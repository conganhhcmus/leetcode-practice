#if DEBUG
namespace Problems_3343;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;

    public int CountBalancedPermutations(string num)
    {
        // odd n+1/2;
        // even = n -odd;
        // permutation of odd and even
        // total sum /2 = target
        // count ways sum of odd elements have sum = target
        // ways * number of permutation of odd and even

        // max = 9*80
        int sum = 0;
        int[] counts = new int[10];
        foreach (char d in num)
        {
            sum += (d - '0');
            counts[d - '0']++;
        }

        if (sum % 2 == 1) return 0;
        int n = num.Length;
        int odd = (n + 1) / 2;
        int even = n - odd;

        int target = sum / 2;
        long[] fact = new long[odd + 1];
        long[] invFact = new long[odd + 1];
        fact[0] = 1;
        invFact[0] = 1;
        for (int i = 1; i <= odd; i++)
        {
            fact[i] = (fact[i - 1] * i) % mod;
        }
        invFact[odd] = FastPower(fact[odd], mod - 2);
        for (int i = odd - 1; i >= 1; i--)
        {
            invFact[i] = (invFact[i + 1] * (i + 1)) % mod;
        }

        Dictionary<string, HashSet<string>> memo = [];
        HashSet<string> candidates = DP(target, odd, 0, num, new int[10], memo);

        long ret = 0;
        foreach (string candidate in candidates)
        {
            int[] odds = new int[10];
            for (int i = 0; i < 10; i++)
            {
                odds[i] = candidate[i] - '0';
            }
            int[] evens = new int[10];
            for (int i = 0; i < 10; i++)
            {
                evens[i] = counts[i] - odds[i];
            }

            ret = (ret + CountWays(odds, evens, fact, invFact, n)) % mod;
        }

        return (int)ret;
    }

    long FastPower(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = (ans * a) % mod;
            }
            a = (a * a) % mod;
            b >>= 1;
        }
        return ans;
    }

    HashSet<string> DP(int target, int n, int pos, string num, int[] curr, Dictionary<string, HashSet<string>> memo)
    {
        if (n == 0)
        {
            if (target != 0) return [];
            return [string.Join("", curr)];
        }
        if (pos >= num.Length) return [];
        string key = $"{target}_{pos}_{n}";
        if (memo.TryGetValue(key, out HashSet<string> cached)) return cached;
        int d = num[pos] - '0';
        curr[d]++;
        HashSet<string> pick = DP(target - d, n - 1, pos + 1, num, curr, memo);
        curr[d]--;
        HashSet<string> nonPick = DP(target, n, pos + 1, num, curr, memo);
        HashSet<string> ret = [.. pick, .. nonPick];
        memo[key] = ret;
        return ret;
    }

    long CountWays(int[] odds, int[] evens, long[] fact, long[] invFact, int n)
    {
        int odd = (n + 1) / 2;
        int even = n - odd;
        long oddWays = fact[odd];
        long evenWays = fact[even];
        for (int i = 0; i < 10; i++)
        {
            oddWays = (oddWays * invFact[odds[i]]) % mod;
            evenWays = (evenWays * invFact[evens[i]]) % mod;
        }

        return (oddWays * evenWays) % mod;
    }
}