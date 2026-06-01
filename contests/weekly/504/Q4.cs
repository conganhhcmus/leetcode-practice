public class Solution
{
    public int[] MaximumMEX(int[] nums)
    {
        int n = nums.Length;
        int[] suf = new int[n];
        bool[] vis = new bool[n + 2];
        int m = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (nums[i] <= n) vis[nums[i]] = true;
            while (vis[m]) m++;
            suf[i] = m;
        }

        List<int> ans = [];
        int k = 0;
        while (k < n)
        {
            int t = suf[k];
            if (t == 0)
            {
                // full 0
                while (k++ < n) ans.Add(0);
                return ans.ToArray();
            }
            // need t distinct element from i..j
            ans.Add(t);
            int req = t;
            bool[] vis2 = new bool[t];
            while (req > 0)
            {
                int v = nums[k];
                if (v < t && vis2[v] == false)
                {
                    vis2[v] = true;
                    req--;
                }
                k++;
            }
        }
        return ans.ToArray();
    }
}
