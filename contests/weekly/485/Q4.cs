public class Solution
{
    public string LexSmallestAfterDeletion(string s)
    {
        int[] rem = new int[26];
        foreach (char c in s)
        {
            rem[c - 'a']++;
        }
        int[] use = new int[26];
        List<char> st = [];
        foreach (char c in s)
        {
            rem[c - 'a']--;
            while (st.Count > 0 && st[^1] > c)
            {
                char x = st[^1];
                if (use[x - 'a'] + rem[x - 'a'] > 1)
                {
                    use[x - 'a']--;
                    st.RemoveAt(st.Count - 1);
                }
                else break;
            }
            st.Add(c);
            use[c - 'a']++;
        }
        while (st.Count > 0)
        {
            int x = st[^1];
            if (use[x - 'a'] > 1)
            {
                st.RemoveAt(st.Count - 1);
                use[x - 'a']--;
            }
            else break;
        }
        return new string(st.ToArray());
    }
}
