public class Solution
{
    public bool DoesAliceWin(string s)
    {
        foreach (char c in s)
        {
            if (IsVowels(c)) return true;
        }
        return false;
    }

    bool IsVowels(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}