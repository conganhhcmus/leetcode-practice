public class Solution
{
    public string MinRemoveToMakeValid(string s)
    {
        char[] arr = s.ToCharArray();
        Stack<int> st = [];
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(')
            {
                st.Push(i);
            }
            else if (s[i] == ')')
            {
                if (st.Count > 0) st.Pop();
                else arr[i] = '#';
            }
        }
        while (st.Count > 0)
        {
            arr[st.Pop()] = '#';
        }
        StringBuilder sb = new();
        foreach (char c in arr)
        {
            if (c == '#') continue;
            sb.Append(c);
        }
        return sb.ToString();
    }
}
