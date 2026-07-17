public class Solution
{
    public string LexPalindromicPermutation(string s, string target)
    {
        int n = s.Length;
        int[] f = new int[26];
        char[] t = target.ToCharArray();
        foreach (char c in s) f[c - 'a']++;
        int cen = -1;
        for (int i = 0; i < 26; i++)
        {
            if ((f[i] & 1) == 1)
            {
                if (cen != -1) return "";
                cen = i;
            }
        }
        for (int i = 0; i < 26; i++) f[i] /= 2;
        if (cen == -1)
        {
            for (int i = 0; i < n / 2; i++)
            {
                f[t[i] - 'a']--;
            }
            if (AllZ(f))
            {
                char[] u = new char[n];
                for (int i = 0; i < n / 2; i++)
                {
                    u[i] = u[n - 1 - i] = t[i];
                }
                string U = new(u);
                if (U.CompareTo(target) > 0) return U;
            }

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                f[t[i] - 'a']++;
                if (!AllNN(f)) continue;
                for (int j = t[i] - 'a' + 1; j < 26; j++)
                {
                    if (f[j] > 0)
                    {
                        f[j]--;
                        char[] u = new char[n];
                        for (int k = 0; k < i; k++)
                        {
                            u[k] = u[n - 1 - k] = t[k];
                        }
                        u[i] = u[n - 1 - i] = (char)(j + 'a');
                        int p = i + 1;
                        for (int c = 0; c < 26; c++)
                        {
                            while (f[c] > 0)
                            {
                                u[p] = u[n - 1 - p] = (char)(c + 'a');
                                f[c]--;
                                p++;
                            }
                        }
                        string U = new(u);
                        return U;
                    }
                }
            }
        }
        else
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                f[t[i] - 'a']--;
            }
            if (AllZ(f))
            {
                char[] u = new char[n];
                u[n / 2] = (char)(cen + 'a');
                for (int i = 0; i < n / 2; i++)
                {
                    u[i] = u[n - 1 - i] = t[i];
                }
                string U = new(u);
                if (U.CompareTo(target) > 0) return U;
            }
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                f[t[i] - 'a']++;
                if (!AllNN(f)) continue;
                for (int j = t[i] - 'a' + 1; j < 26; j++)
                {
                    if (f[j] > 0)
                    {
                        f[j]--;
                        char[] u = new char[n];
                        u[n / 2] = (char)(cen + 'a');
                        for (int k = 0; k < i; k++)
                        {
                            u[k] = u[n - 1 - k] = t[k];
                        }
                        u[i] = u[n - 1 - i] = (char)('a' + j);
                        int p = i + 1;
                        for (int c = 0; c < 26; c++)
                        {
                            while (f[c] > 0)
                            {
                                u[p] = u[n - 1 - p] = (char)(c + 'a');
                                f[c]--;
                                p++;
                            }
                        }
                        string U = new(u);
                        return U;
                    }
                }
            }
        }
        return "";
    }

    bool AllZ(int[] f)
    {
        foreach (int v in f)
        {
            if (v != 0) return false;
        }
        return true;
    }
    // all non-negative
    bool AllNN(int[] f)
    {
        foreach (int v in f)
        {
            if (v < 0) return false;
        }
        return true;
    }
}
