#if DEBUG
namespace Problems_290;
#endif

public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');
        if (pattern.Length != words.Length) return false;

        Dictionary<char, string> map1 = [];
        Dictionary<string, char> map2 = [];

        for (var i = 0; i < pattern.Length; i++)
        {
            var c = pattern[i];
            var word = words[i];

            if (map1.ContainsKey(c) && map1[c] != word) return false;
            if (map2.ContainsKey(word) && map2[word] != c) return false;

            map1[c] = word;
            map2[word] = c;
        }

        return true;
    }
}