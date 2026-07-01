public class Solution
{
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> dict = [.. wordList];
        if (!dict.Contains(endWord)) return [];
        Dictionary<string, List<string>> parents = [];
        HashSet<string> current = [beginWord];
        HashSet<string> visited = [beginWord];

        bool found = false;
        while (current.Count > 0 && !found)
        {
            HashSet<string> next = [];
            foreach (string word in current) dict.Remove(word);
            foreach (string word in current)
            {
                char[] arr = word.ToCharArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    char old = arr[i];
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c == old) continue;
                        arr[i] = c;
                        string nei = new(arr);
                        if (!dict.Contains(nei)) continue;
                        next.Add(nei);
                        if (!parents.TryGetValue(nei, out var list))
                        {
                            list = [];
                            parents[nei] = list;
                        }
                        list.Add(word);
                        if (nei == endWord) found = true;
                    }
                    arr[i] = old;
                }
            }
            current = next;
        }

        IList<IList<string>> ans = [];
        if (!found) return ans;
        List<string> path = [endWord];
        Dfs(endWord);
        return ans;

        void Dfs(string word)
        {
            if (word == beginWord)
            {
                List<string> res = [.. path];
                res.Reverse();
                ans.Add(res);
                return;
            }
            if (!parents.TryGetValue(word, out var list)) return;
            foreach (string p in list)
            {
                path.Add(p);
                Dfs(p);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
