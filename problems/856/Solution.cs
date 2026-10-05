public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        Stack<int> st = [];
        st.Push(0);
        foreach (char c in s)
        {
            if (c == '(') st.Push(0);
            else
            {
                int v = st.Pop();
                int w = st.Pop();
                st.Push(w + Math.Max(2 * v, 1));
            }
        }
        return st.Pop();
    }
}