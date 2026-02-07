public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int ans = 0;
        int i = s.Length - 1;
        while (i >= 0 && s[i] == ' ') i--;
        while (i >= 0 && s[i] != ' ')
        {
            ans++;
            i--;
        }

        return ans;
    }
}