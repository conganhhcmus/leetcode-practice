public class Solution
{
    public int[] MinDeletions(string s, int[][] queries)
    {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        int[] diff = new int[n];
        FenwickTree tree = new(n);
        for (int i = 1; i < n; i++)
        {
            if (arr[i] != arr[i - 1]) continue;
            diff[i] = 1;
            tree.Update(i, 1);
        }
        List<int> ans = [];
        foreach (int[] q in queries)
        {
            if (q[0] == 1)
            {
                int idx = q[1];
                arr[idx] = (arr[idx] == 'A') ? 'B' : 'A';
                Update(idx);
                Update(idx + 1);
            }
            else
            {
                int l = q[1], r = q[2];
                ans.Add(tree.Query(r) - tree.Query(l));
            }
        }
        return ans.ToArray();

        void Update(int i)
        {
            if (i <= 0 || i >= n) return;
            int val = (arr[i] == arr[i - 1]) ? 1 : 0;
            tree.Update(i, val - diff[i]);
            diff[i] = val;
        }
    }

    class FenwickTree
    {
        int[] bit;
        int n;
        public FenwickTree(int size)
        {
            n = size;
            bit = new int[n + 2];
        }

        public void Update(int i, int val)
        {
            i++;
            while (i <= n)
            {
                bit[i] += val;
                i += i & -i;
            }
        }

        public int Query(int i)
        {
            i++;
            int sum = 0;
            while (i > 0)
            {
                sum += bit[i];
                i -= i & -i;
            }
            return sum;
        }
    }
}
