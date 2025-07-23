#if DEBUG
namespace Problems_1717_2;
#endif

public class Solution
{
    public int MaximumGain(string s, int x, int y)
    {
        int ans = 0;
        char[] a = s.ToCharArray();
        if (x > y)
        {
            ans += Solve(ref a, "ab", x);
            ans += Solve(ref a, "ba", y);
        }
        else
        {
            ans += Solve(ref a, "ba", y);
            ans += Solve(ref a, "ab", x);
        }
        return ans;
    }

    int Solve(ref char[] s, string pattern, int val)
    {
        int ans = 0;
        int w = 0;
        for (int r = 0; r < s.Length; r++)
        {
            s[w++] = s[r];
            if (w > 1 && s[w - 2] == pattern[0] && s[w - 1] == pattern[1])
            {
                w -= 2;
                ans += val;
            }
        }

        s = s[..w];

        return ans;
    }
}