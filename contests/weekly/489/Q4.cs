public class Trie
{
    public Trie[] child = new Trie[2];
    public int Count = 0;

    public void Add(int val)
    {
        Trie node = this;
        for (int b = 31; b >= 0; b--)
        {
            int bit = (val >> b) & 1;

            if (node.child[bit] == null)
                node.child[bit] = new Trie();

            node = node.child[bit];
            node.Count++;
        }
    }

    public void Remove(int val)
    {
        Trie node = this;
        for (int b = 31; b >= 0; b--)
        {
            int bit = (val >> b) & 1;
            node = node.child[bit];
            node.Count--;
        }
    }

    public int GetMaxXor(int val)
    {
        Trie node = this;
        int ans = 0;

        for (int b = 31; b >= 0; b--)
        {
            int bit = (val >> b) & 1;
            int want = bit ^ 1;

            if (node.child[want] != null && node.child[want].Count > 0)
            {
                ans |= (1 << b);
                node = node.child[want];
            }
            else
            {
                node = node.child[bit];
            }
        }

        return ans;
    }
}

public class Solution
{
    public int MaxXor(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = 0;
        LinkedList<int> dqMin = new(); // increase
        LinkedList<int> dqMax = new(); // decrease
        int rXor = 0;
        int lXor = 0;
        Trie trie = new();
        trie.Add(rXor);
        for (int r = 0, l = 0; r < n; r++)
        {
            rXor ^= nums[r];
            trie.Add(rXor);

            while (dqMin.Count > 0 && nums[dqMin.Last.Value] >= nums[r])
            {
                dqMin.RemoveLast();
            }
            dqMin.AddLast(r);

            while (dqMax.Count > 0 && nums[dqMax.Last.Value] <= nums[r])
            {
                dqMax.RemoveLast();
            }
            dqMax.AddLast(r);

            int min = nums[dqMin.First.Value];
            int max = nums[dqMax.First.Value];
            while (max - min > k)
            {
                while (dqMin.Count > 0 && dqMin.First.Value <= l)
                {
                    dqMin.RemoveFirst();
                }
                while (dqMax.Count > 0 && dqMax.First.Value <= l)
                {
                    dqMax.RemoveFirst();
                }
                min = nums[dqMin.First.Value];
                max = nums[dqMax.First.Value];
                trie.Remove(lXor);
                lXor ^= nums[l];
                l++;
            }
            ans = Math.Max(ans, trie.GetMaxXor(rXor));
        }
        return ans;
    }
}