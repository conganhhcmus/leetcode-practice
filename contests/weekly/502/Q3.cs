public class Solution
{
    public int CountLocalMaximums(int[][] matrix)
    {
        int n = matrix.Length, m = matrix[0].Length;
        // 200 x 200 ~ 4.10^4
        int s = n * m;
        int[] a = new int[s];
        List<(int r, int c)> arr = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int x = matrix[i][j];
                if (x > 0)
                {
                    int idx = i * m + j;
                    a[idx] = x;
                    arr.Add((i, j));
                }
            }
        }

        SegmentTree tree = new(a);
        int count = 0;
        foreach (var (r, c) in arr)
        {
            // check if matrix[i][j] is local maximums
            // x = matrix[i][j]
            // i - x, j - x
            // i - x, j + x
            // i + x, j - x
            // i + x, j + x
            // j - x, j + x
            // skip i - x, i + x
            int x = matrix[r][c];
            bool valid = true;
            for (int k = Math.Max(0, r - x); k <= Math.Min(n - 1, r + x); k++)
            {
                int st = Math.Max(0, c - x);
                int ed = Math.Min(m - 1, c + x);
                if (k == r - x || k == r + x)
                {
                    if (st == c - x) st++;
                    if (ed == c + x) ed--;
                }
                if (!tree.Query(k * m + st, k * m + ed, x))
                {
                    valid = false;
                    break;
                }
            }
            if (valid) count++;
        }
        return count;
    }
}

public class SegmentTree
{
    int n;
    int[] tree;
    public SegmentTree(int[] nums)
    {
        n = nums.Length;
        tree = new int[4 * n];
        Build(0, n - 1, 1, nums);
    }

    void Build(int left, int right, int node, int[] nums)
    {
        if (left == right)
        {
            tree[node] = nums[left];
            return;
        }
        int mid = left + (right - left) / 2;
        Build(left, mid, 2 * node, nums);
        Build(mid + 1, right, 2 * node + 1, nums);
        tree[node] = Math.Max(tree[2 * node], tree[2 * node + 1]);
    }

    public bool Query(int qleft, int qright, int val) => Query(0, n - 1, 1, qleft, qright, val);

    bool Query(int left, int right, int node, int qleft, int qright, int val)
    {
        if (qleft > right || qright < left) return true;
        if (qleft <= left && qright >= right) return tree[node] <= val;
        int mid = left + (right - left) / 2;
        bool l = Query(left, mid, 2 * node, qleft, qright, val);
        if (!l) return l;
        bool r = Query(mid + 1, right, 2 * node + 1, qleft, qright, val);
        return r;
    }
}
