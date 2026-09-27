public class Solution
{
    public string ReverseParentheses(string s)
    {
        int n = s.Length;
        const char L = '(';
        const char R = ')';
        Stack<int> st = [];
        int[] pair = new int[n];
        for (int i = 0; i < n; i++)
        {
            pair[i] = 0;
            if (L == s[i])
            {
                st.Push(i);
            }
            if (R == s[i])
            {
                int j = st.Pop();
                pair[i] = j;
                pair[j] = i;
            }
        }
        StringBuilder sb = new();
        for (int i = 0, d = 1; i < n; i += d)
        {
            if (L == s[i] || R == s[i])
            {
                i = pair[i];
                d = -1 * d;
            }
            else
            {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
}