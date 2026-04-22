public class Solution
{
    public string DecodeString(string s)
    {
        int i = 0;
        return Dfs(s, ref i);
    }

    string Dfs(string s, ref int i)
    {
        int n = s.Length;
        string result = "";
        while (i < n && s[i] != ']')
        {
            if (char.IsLetter(s[i]))
            {
                result += s[i];
                i++;
            }
            else if (char.IsDigit(s[i]))
            {
                int k = 0;
                // build number
                while (i < n && char.IsDigit(s[i]))
                {
                    k = k * 10 + (s[i] - '0');
                    i++;
                }

                i++; // skip '['

                string decoded = Dfs(s, ref i);

                i++; // skip ']'

                // repeat k times
                for (int j = 0; j < k; j++)
                {
                    result += decoded;
                }
            }
        }

        return result;
    }
}
