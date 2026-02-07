public class Solution
{
    public string GenerateString(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;
        char[] ans = new char[n + m - 1];
        Array.Fill(ans, '?');
        // Handling T cases
        char[] source = str2.ToCharArray();
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'F') continue;
            Array.Copy(source, 0, ans, i, m);
        }

        for (int i = 0; i < n; i++)
        {
            bool isSame = IsSame(new string(ans, i, m), str2);
            if (str1[i] == 'F' && isSame) return "";
            if (str1[i] == 'T' && !isSame) return "";
        }

        // Fill remaining characters
        bool[] canChange = new bool[n + m - 1];
        for (int i = 0; i < ans.Length; i++)
        {
            if (ans[i] == '?')
            {
                ans[i] = 'a';
                canChange[i] = true;
            }
        }

        // Handling F cases
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'T') continue;
            bool isSame = IsSame(new string(ans, i, m), str2);
            if (!isSame) continue;
            bool cannot = true;
            for (int j = m - 1; j >= 0; j--)
            {
                if (canChange[i + j])
                {
                    ans[i + j]++;
                    i += j;
                    cannot = false;
                    break;
                }
            }
            if (cannot) return "";
        }

        return new string(ans);
    }

    bool IsSame(string a, string b)
    {
        return a.Length == b.Length && a == b;
    }
}