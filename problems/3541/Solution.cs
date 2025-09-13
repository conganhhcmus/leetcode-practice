#if DEBUG
namespace Problems_3541;
#endif

public class Solution
{
    public int MaxFreqSum(string s)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }
        int vowel = 0;
        int consonant = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            if (IsVowel(c))
            {
                vowel = Math.Max(vowel, count[c - 'a']);
            }
            else
            {
                consonant = Math.Max(consonant, count[c - 'a']);
            }
        }

        return consonant + vowel;
    }

    bool IsVowel(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}