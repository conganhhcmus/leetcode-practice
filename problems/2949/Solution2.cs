public class Solution
{
    public int BeautifulSubstrings(string s, int k)
    {
        int n = s.Length;
        int[] count = new int[n + 1];
        for (int i = 0; i < n; ++i)
        {
            count[i + 1] = count[i] + (IsVowel(s[i]) ? 1 : 0);
        }
        int ret = 0;
        Dictionary<(int, int), int> map = [];
        int M = ComputeM(k);

        for (int i = 0; i <= n; ++i)
        {
            int vowels = count[i];
            int consonants = i - vowels;
            int diff = vowels - consonants;
            int mod = vowels % M;

            // condition 1: 
            // vowels[r] - vowels[l] = consonants[r] - consonants[l]
            // vowels[r] - consonants[r] = vowels[l] - consonants[l]
            // diff[r] == diff[l]
            // condition 2:
            // vowels * consonants % k == 0
            // vowels^2 = 0 (mod k)
            // if k = p1^x1 * p2^x2 ... where p1 is prime
            // give M = p1^((x1+1)/2) * p2^((x2+1)/2) ... where (x+1)/2 is ceil technique
            // vowels^2 = 0 (mod k) => vowels = 0 (mod M)

            ret += map.GetValueOrDefault((diff, mod), 0);
            map[(diff, mod)] = map.GetValueOrDefault((diff, mod), 0) + 1;
        }
        return ret;
    }

    int ComputeM(int k)
    {
        Dictionary<int, int> factors = GetFactor(k);
        int ret = 1;
        foreach (var pair in factors)
        {
            ret *= FastPow(pair.Key, (pair.Value + 1) / 2);
        }
        return ret;
    }

    int FastPow(int a, int b)
    {
        int ret = 1;
        while (b > 0)
        {
            if ((b & 1) != 0) ret *= a;
            a *= a;
            b >>= 1;
        }
        return ret;
    }

    Dictionary<int, int> GetFactor(int k)
    {
        Dictionary<int, int> factors = [];
        while (k % 2 == 0)
        {
            factors[2] = factors.GetValueOrDefault(2, 0) + 1;
            k /= 2;
        }
        for (int i = 3; i <= k; i += 2)
        {
            while (k % i == 0)
            {
                factors[i] = factors.GetValueOrDefault(i, 0) + 1;
                k /= i;
            }
        }
        return factors;
    }

    bool IsVowel(char a)
    {
        return a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u';
    }
}