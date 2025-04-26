#if DEBUG
namespace Problems_2947;
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
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j <= i; ++j)
            {
                int len = i - j + 1;
                int vowels = count[i + 1] - count[j];
                if (vowels * 2 == len && vowels * vowels % k == 0) ret++;
            }
        }
        return ret;
    }

    bool IsVowel(char a)
    {
        return a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u';
    }
}