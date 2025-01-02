#if DEBUG
namespace Problems_49;
#endif

public class Solution
{
    string GetKey(string str)
    {
        var chars = str.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        int n = strs.Length;
        IList<IList<string>> result = [];
        Dictionary<string, int> groups = [];
        for (int i = 0; i < n; i++)
        {
            string key = GetKey(strs[i]);
            if (groups.ContainsKey(key))
            {
                result[groups[key]].Add(strs[i]);
            }
            else
            {
                groups[key] = result.Count;
                result.Add([strs[i]]);
            }
        }

        return result;
    }
}