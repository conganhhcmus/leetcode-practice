public class Solution
{
    public string ReverseParentheses(string s)
    {
        Stack<char> st = [];
        foreach (char c in s)
        {
            if (c == ')')
            {
                List<char> tmp = [];
                while (st.Count > 0 && st.Peek() != '(')
                {
                    tmp.Add(st.Pop());
                }
                if (st.Count > 0 && st.Peek() == '(') st.Pop();
                foreach (char x in tmp)
                {
                    st.Push(x);
                }
            }
            else st.Push(c);
        }
        StringBuilder sb = new();
        while (st.Count > 0)
        {
            sb.Append(st.Pop());
        }
        char[] ans = sb.ToString().ToCharArray();
        Array.Reverse(ans);
        return new string(ans);
    }
}