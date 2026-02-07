public class Solution
{
    public string RobotWithString(string s)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }
        Stack<char> st = new();
        StringBuilder sb = new();
        int minCh = 'a';
        int i = 0, n = s.Length;
        while (i < n)
        {
            while (minCh <= 'z' && count[minCh - 'a'] <= 0) minCh++;
            if (st.Count > 0 && st.Peek() <= minCh)
            {
                sb.Append(st.Pop());
            }
            else
            {
                st.Push(s[i]);
                count[s[i] - 'a']--;
                i++;
            }
        }
        while (st.Count > 0)
        {
            sb.Append(st.Pop());
        }
        return sb.ToString();
    }
}