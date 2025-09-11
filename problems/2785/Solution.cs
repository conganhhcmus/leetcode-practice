#if DEBUG
namespace Problems_2785;
#endif

public class Solution
{
    public string SortVowels(string s)
    {
        List<char> vowels = [];
        int n = s.Length;
        char[] str = s.ToCharArray();
        for (int i = 0; i < n; i++)
        {
            if (IsVowels(s[i]))
            {
                vowels.Add(s[i]);
                str[i] = '#';
            }
        }

        vowels.Sort();
        for (int i = 0, j = 0; i < n && j < vowels.Count; i++)
        {
            if (str[i] == '#')
            {
                str[i] = vowels[j++];
            }
        }

        return new(str);
    }

    bool IsVowels(char c)
        => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
        || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
}