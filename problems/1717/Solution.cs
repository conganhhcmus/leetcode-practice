#if DEBUG
namespace Problems_1717;
#endif

public class Solution
{
    public int MaximumGain(string s, int x, int y)
    {
        int ans = 0;
        if (x > y)
        {
            ans += Solve(ref s, "ab", x);
            ans += Solve(ref s, "ba", y);
        }
        else
        {
            ans += Solve(ref s, "ba", y);
            ans += Solve(ref s, "ab", x);
        }

        return ans;
    }

    int Solve(ref string s, string pattern, int val)
    {
        Stack<char> st = new();
        int ans = 0;
        foreach (char c in s)
        {
            if (st.Count > 0 && st.Peek() == pattern[0] && c == pattern[1])
            {
                ans += val;
                st.Pop();
                continue;
            }
            st.Push(c);
        }
        StringBuilder sb = new();
        while (st.Count > 0)
        {
            sb.Append(st.Pop());
        }
        char[] tmp = sb.ToString().ToCharArray();
        Array.Reverse(tmp);
        s = new(tmp);

        return ans;
    }
}