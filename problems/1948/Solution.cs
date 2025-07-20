#if DEBUG
namespace Problems_1948;
#endif

public class Solution
{
    readonly List<IList<string>> ans = [];
    readonly Dictionary<string, int> freq = [];

    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        TrieNode root = new();
        foreach (var path in paths)
        {
            TrieNode curr = root;
            foreach (string folderName in path)
            {
                if (!curr.Children.ContainsKey(folderName))
                {
                    curr.Children[folderName] = new();
                }
                curr = curr.Children[folderName];
            }
        }

        DFS(root);

        Backtracking(root, []);

        return ans;
    }

    void DFS(TrieNode node)
    {
        if (node.Children.Count == 0) return;
        List<string> hash = [];
        foreach (var next in node.Children)
        {
            DFS(next.Value);
            hash.Add($"{next.Key}({next.Value.Serial})");
        }
        hash.Sort();
        node.Serial = string.Join("", hash);
        freq[node.Serial] = freq.GetValueOrDefault(node.Serial, 0) + 1;
    }

    void Backtracking(TrieNode node, List<string> path)
    {
        if (freq.TryGetValue(node.Serial, out int count) && count > 1) return;
        if (path.Count > 0) ans.Add([.. path]);
        foreach (var next in node.Children)
        {
            path.Add(next.Key);
            Backtracking(next.Value, path);
            path.RemoveAt(path.Count - 1);
        }
    }
}

public class TrieNode
{
    public string Serial;
    public Dictionary<string, TrieNode> Children;

    public TrieNode()
    {
        Serial = "";
        Children = [];
    }
}