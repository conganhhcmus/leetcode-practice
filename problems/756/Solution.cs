public class Solution
{
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        Dictionary<string, List<char>> map = [];
        foreach (string str in allowed)
        {
            string key = str[..2];
            char val = str[2];
            map.TryAdd(key, []);
            map[key].Add(val);
        }
        return BuildPyramid("", bottom, map);
    }

    Dictionary<string, bool> memo = [];

    bool BuildPyramid(string cur, string bottom, Dictionary<string, List<char>> map)
    {
        if (bottom.Length == 1) return true;

        if (cur.Length == 0 && memo.TryGetValue(bottom, out bool cached))
            return cached;

        int i = cur.Length;

        if (i == bottom.Length - 1)
        {
            bool res = BuildPyramid("", cur, map);
            memo[bottom] = res;
            return res;
        }

        string key = "" + bottom[i] + bottom[i + 1];
        if (!map.ContainsKey(key)) return false;

        foreach (char c in map[key])
        {
            if (BuildPyramid(cur + c, bottom, map)) return true;
        }

        return false;
    }
}