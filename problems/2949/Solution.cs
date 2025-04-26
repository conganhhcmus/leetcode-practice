#if DEBUG
namespace Problems_2949;
#endif

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
        List<int> candidates = GetCandidate(k);

        for (int i = 0; i <= n; ++i)
        {
            int vowels = count[i];
            int consonants = i - vowels;
            int diff = vowels - consonants;
            int mod = vowels % k;

            // condition 1: 
            // vowels[r] - vowels[l] = consonants[r] - consonants[l]
            // vowels[r] - consonants[r] = vowels[l] - consonants[l]
            // diff[r] == diff[l]
            // condition 2:
            // vowels * consonants % k == 0
            // vowels * vowels % k == 0
            // (vowels % k) = x where x * x % k == 0
            // vowels[r] % k - vowels[l] % k  = x
            // vowels[r] % k - x = vowels[l] % k
            foreach (int x in candidates)
            {
                int remain = (mod - x + k) % k;
                ret += map.GetValueOrDefault((diff, remain), 0);
            }
            map[(diff, mod)] = map.GetValueOrDefault((diff, mod), 0) + 1;
        }
        return ret;
    }

    List<int> GetCandidate(int n)
    {
        List<int> ret = [];
        for (int i = 1; i <= n; ++i)
        {
            if ((1L * i * i) % n == 0)
            {
                ret.Add(i);
            }
        }
        return ret;
    }

    bool IsVowel(char a)
    {
        return a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u';
    }
}