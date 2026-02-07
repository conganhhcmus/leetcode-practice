public class Solution
{
    public bool IsValid(string word)
    {
        if (word.Length < 3) return false;
        char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        bool hasVowels = false;
        bool hasConsonant = false;
        foreach (char c in word)
        {
            if (char.IsDigit(c)) continue;
            if (char.IsLetter(c))
            {
                if (vowels.Contains(c))
                {
                    hasVowels = true;
                }
                else
                {
                    hasConsonant = true;
                }
                continue;
            }
            return false;
        }
        return hasVowels && hasConsonant;
    }
}