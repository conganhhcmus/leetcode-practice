public class Solution
{
    long ans = 0;
    Dictionary<int, long> freq = [];
    public long CountPalindromePaths(IList<int> parent, string s)
    {
        int n = parent.Count;
        List<int>[] tree = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            tree[i] = [];
        }
        for (int i = 1; i < n; i++)
        {
            tree[parent[i]].Add(i);
        }
        // use bit mask to present a state of string.
        // attend the palindrome string, it have a most only one odd freq character
        // so use 26 bit to present the state of string.
        // ab => ...11, aa => ...00, aab => ...10
        // define mask[u] = bit mask from 0 to u, mask[v] = bit mask from 0 to v
        // to check from u to v have valid palindrome string, can use mask[u] ^ mask[v] has only one set bit
        freq[0] = 1;

        DFS(0, 0, s, tree);
        return ans;
    }

    void DFS(int curr, int mask, string s, List<int>[] tree)
    {
        foreach (int next in tree[curr])
        {
            int newMask = mask ^ (1 << (s[next] - 'a'));

            // case 1: count the same mask
            if (freq.ContainsKey(newMask))
            {
                ans += freq[newMask];
            }

            // case 2: count the exactly diff one bit
            for (int i = 0; i < 26; i++)
            {
                int t = newMask ^ (1 << i);
                if (freq.ContainsKey(t))
                {
                    ans += freq[t];
                }
            }

            if (!freq.ContainsKey(newMask))
            {
                freq[newMask] = 0;
            }
            freq[newMask]++;
            DFS(next, newMask, s, tree);
        }
    }
}