public class Solution
{
    public int[] LongestCommonPrefix(string[] words, int k)
    {
        int n = words.Length;
        Trie trie = new Trie(0);
        int maxLength = 0;
        foreach (string word in words)
        {
            trie.Insert(word);
            maxLength = Math.Max(maxLength, word.Length);
        }
        int[] freq = trie.BuildFreq(k, maxLength);
        Dictionary<string, int> memo = [];
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (memo.TryGetValue(words[i], out int cached))
            {
                ans[i] = cached;
            }
            else
            {
                List<Trie> paths = trie.GetPath(words[i]);
                Remove(paths, freq, k);
                ans[i] = GetMaxDepth(freq, k);
                RollBack(paths, freq, k);
                memo[words[i]] = ans[i];
            }
        }

        return ans;
    }
    int GetMaxDepth(int[] freq, int k)
    {
        int ret = freq.Length - 1;
        while (ret > 0 && freq[ret] == 0)
        {
            ret--;
        }
        return ret;
    }

    void Remove(List<Trie> paths, int[] freq, int k)
    {
        foreach (Trie node in paths)
        {
            int oldCount = node.count;
            node.count--;
            if (oldCount == k)
            {
                freq[node.depth]--;
            }
        }
    }

    void RollBack(List<Trie> paths, int[] freq, int k)
    {
        foreach (Trie node in paths)
        {
            int oldCount = node.count;
            node.count++;
            if (oldCount == k - 1)
            {
                freq[node.depth]++;
            }
        }
    }
}

public class Trie
{
    public int count;

    public int depth;
    public Dictionary<char, Trie> children;

    public Trie(int depth)
    {
        this.count = 0;
        this.depth = depth;
        this.children = [];
    }

    public void Insert(string s)
    {
        Trie current = this;
        current.count++;
        foreach (char c in s)
        {
            if (!current.children.TryGetValue(c, out Trie value))
            {
                value = new(current.depth + 1);
                current.children[c] = value;
            }
            current = value;
            current.count++;
        }
    }

    public List<Trie> GetPath(string s)
    {
        Trie current = this;
        List<Trie> paths = [];
        paths.Add(current);
        foreach (char c in s)
        {
            if (current.children.TryGetValue(c, out Trie value))
            {
                current = value;
                paths.Add(current);
            }
            else break;
        }

        return paths;
    }

    public int[] BuildFreq(int k, int maxDepth)
    {
        int[] freq = new int[maxDepth + 1];
        Trie current = this;
        Stack<Trie> stack = [];
        stack.Push(current);
        while (stack.Count > 0)
        {
            Trie node = stack.Pop();
            if (node.count >= k) freq[node.depth]++;
            foreach (var child in node.children.Values)
            {
                stack.Push(child);
            }
        }
        return freq;
    }
}