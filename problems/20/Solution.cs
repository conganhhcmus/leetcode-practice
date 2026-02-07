public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> st = new(s.Length);
        foreach (char ch in s)
        {
            if (ch == '(' || ch == '{' || ch == '[') st.Push(ch);
            else
            {
                if (st.Count == 0) return false;
                char top = st.Pop();
                if ((ch == ')' && top != '(') ||
                    (ch == '}' && top != '{') ||
                    (ch == ']' && top != '['))
                    return false;
            }

        }
        return st.Count == 0;
    }
}