#if DEBUG
namespace Problems_2785_2;
#endif

public class Solution
{
    public string SortVowels(string s)
    {
        string sortedVowel = "AEIOUaeiou";
        Dictionary<char, int> count = [];
        foreach (char c in s)
        {
            if (IsVowels(c))
            {
                count[c] = count.GetValueOrDefault(c, 0) + 1;
            }
        }

        StringBuilder sb = new();
        int i = 0;
        foreach (char c in s)
        {
            if (IsVowels(c))
            {
                while (count.GetValueOrDefault(sortedVowel[i], 0) == 0)
                {
                    i++;
                }
                sb.Append(sortedVowel[i]);
                count[sortedVowel[i]]--;
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    bool IsVowels(char c)
    => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
    || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
}