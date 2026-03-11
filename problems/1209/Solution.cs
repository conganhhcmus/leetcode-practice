public class Solution
{
    public string RemoveDuplicates(string s, int k)
    {
        Stack<(char k, int v)> st = [];
        foreach (char c in s)
        {
            if (st.Count > 0 && st.Peek().k == c)
            {
                var e = st.Pop();
                st.Push((e.k, e.v + 1));
            }
            else
            {
                st.Push((c, 1));
            }

            if (st.Peek().v == k) st.Pop();
        }
        string ans = "";
        while (st.Count > 0)
        {
            var e = st.Pop();
            ans = new string(e.k, e.v) + ans;
        }
        return ans;
    }
}