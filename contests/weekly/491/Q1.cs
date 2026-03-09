public class Solution
{
    public string TrimTrailingVowels(string s)
    {
        string ans = "";
        int n = s.Length - 1;
        while (n >= 0)
        {
            if (IsVowels(s[n])) n--;
            else break;
        }

        for (int i = 0; i <= n; i++)
        {
            ans += s[i];
        }

        return ans;
    }

    bool IsVowels(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}