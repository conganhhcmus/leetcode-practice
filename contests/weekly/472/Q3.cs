public class Solution
{
    public string LexGreaterPermutation(string s, string target)
    {
        int n = s.Length;
        int[] cnt = new int[26];
        for (int i = 0; i < n; i++) cnt[s[i] - 'a']++;
        // fixed 0..i
        for (int i = n - 1; i >= 0; i--)
        {
            int[] freq = Calc(i);
            if (freq.Length != 0)
            {
                char[] a = new char[n];
                for (int j = 0; j < i; j++) a[j] = target[j];
                bool ok = false;
                for (int j = target[i] - 'a' + 1; j < 26; j++)
                {
                    if (freq[j] == 0) continue;
                    a[i] = (char)(j + 'a');
                    freq[j]--;
                    ok = true;
                    break;
                }
                if (ok)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        for (int k = 0; k < 26; k++)
                        {
                            if (freq[k] == 0) continue;
                            a[j] = (char)(k + 'a');
                            freq[k]--;
                            break;
                        }
                    }
                    return new(a);
                }
            }
        }
        return "";

        int[] Calc(int k)
        {
            int[] freq = new int[26];
            Array.Copy(cnt, freq, 26);
            for (int i = 0; i < k; i++)
            {
                freq[target[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
            {
                if (freq[i] < 0) return [];
            }
            return freq;
        }
    }
}
