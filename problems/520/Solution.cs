public class Solution
{
    public bool DetectCapitalUse(string word)
    {
        int n = word.Length;
        if (!IsCapital(word[0]))
        {
            for (int i = 1; i < n; i++)
            {
                if (IsCapital(word[i])) return false;
            }
        }
        else
        {
            for (int i = 1; i < n - 1; i++)
            {
                if (IsCapital(word[i]) != IsCapital(word[i + 1])) return false;
            }
        }
        return true;
    }
    bool IsCapital(char c) => c >= 'A' && c <= 'Z';
}