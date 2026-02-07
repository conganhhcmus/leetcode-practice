public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        var map = new Dictionary<char, List<string>>{
            {'2',["a","b","c"]},
            {'3',["d","e","f"]},
            {'4',["g","h","i"]},
            {'5',["j","k","l"]},
            {'6',["m","n","o"]},
            {'7',["p","q","r","s"]},
            {'8',["t","u","v"]},
            {'9',["w","x","y","z"]},
        };

        IList<string> ret = [];
        BackTracking(0, "", digits, ret, map);
        return ret;
    }

    void BackTracking(int pos, string candidate, string digits, IList<string> ret, Dictionary<char, List<string>> map)
    {
        if (digits.Length == 0) return;
        if (pos >= digits.Length)
        {
            ret.Add(candidate);
            return;
        }

        foreach (string letter in map[digits[pos]])
        {
            BackTracking(pos + 1, candidate + letter, digits, ret, map);
        }
    }
}