#if DEBUG
namespace Problems_2131;
#endif

public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        Dictionary<string, int> count = [];
        foreach (string word in words)
        {
            count[word] = count.GetValueOrDefault(word, 0) + 1;
        }
        int ret = 0;
        bool extra = false;
        HashSet<string> visited = [];
        foreach (var pair in count)
        {
            string key1 = pair.Key;
            string key2 = Reverse(pair.Key);
            if (!visited.Add(key1)) continue;
            visited.Add(key2);
            int count1 = count.GetValueOrDefault(key1, 0);
            int count2 = count.GetValueOrDefault(key2, 0);
            if (key1 == key2)
            {
                ret += 4 * (Math.Min(count1, count2) / 2);
                if (count1 % 2 == 1)
                {
                    extra = true;
                }
            }
            else
            {
                ret += 4 * Math.Min(count1, count2);
            }

        }
        if (extra) ret += 2;
        return ret;
    }

    string Reverse(string s)
    {
        char[] charArr = s.ToCharArray();
        Array.Reverse(charArr);
        return new string(charArr);
    }
}