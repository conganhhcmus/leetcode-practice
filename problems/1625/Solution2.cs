#if DEBUG
namespace Problems_1625_2;
#endif

public class Solution
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        int n = s.Length;
        s = s + s; // double s for rotate easy
        string ans = s;
        bool[] vis = new bool[n];
        for (int i = 0; !vis[i]; i = (i + b) % n)
        {
            vis[i] = true;
            for (int j = 0; j < 10; j++)
            {
                int kLimit = b % 2 == 0 ? 0 : 9;
                for (int k = 0; k <= kLimit; k++)
                {
                    char[] t = s.Substring(i, n).ToCharArray();
                    for (int p = 1; p < n; p += 2)
                    {
                        t[p] = (char)('0' + (t[p] - '0' + j * a) % 10);
                    }

                    for (int p = 0; p < n; p += 2)
                    {
                        t[p] = (char)('0' + (t[p] - '0' + k * a) % 10);
                    }

                    string tStr = new(t);
                    if (ans.CompareTo(tStr) > 0)
                    {
                        ans = tStr;
                    }
                }
            }
        }

        return ans;
    }
}