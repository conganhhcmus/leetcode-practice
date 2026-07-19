public class Solution
{
    public string SmallestSubsequence(string s)
    {
        int[] freq = new int[26];
        bool[] used = new bool[26];
        foreach (char c in s) freq[c - 'a']++;
        Stack<char> st = [];
        foreach (char c in s)
        {
            int idx = c - 'a';
            freq[idx]--;
            if (used[idx]) continue;
            while (st.Count > 0)
            {
                char top = st.Peek();
                if (top <= c) break;
                if (freq[top - 'a'] == 0) break;
                used[top - 'a'] = false;
                st.Pop();
            }
            st.Push(c);
            used[idx] = true;
        }
        char[] ans = st.ToArray();
        Array.Reverse(ans);
        return new string(ans);
    }
}
