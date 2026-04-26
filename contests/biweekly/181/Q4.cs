
public class Solution
{
    public int[] KthRemainingInteger(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        Fenwich tree = new(n);
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0)
            {
                tree.Update(i + 1, 1);
            }
        }
        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1], k = queries[i][2];
            int low = 1, high = 1 << 30, res = 0;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int removed = Count(l, r, mid);
                if (mid - removed >= k)
                {
                    res = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            ans[i] = 2 * res;
        }
        return ans;

        int Count(int l, int r, int k)
        {
            int low = l, high = r;
            int t = 2 * k;
            int p = l - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] <= t)
                {
                    p = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (p < l) return 0;
            return tree.Query(p + 1) - tree.Query(l);
        }
    }
}

public class Fenwich
{
    private int[] tree;
    private int n;

    public Fenwich(int n)
    {
        this.n = n;
        tree = new int[n + 1];
    }

    public int Query(int i)
    {
        int sum = 0;
        while (i > 0)
        {
            sum += tree[i];
            i -= i & -i;
        }

        return sum;
    }

    public void Update(int i, int v)
    {
        while (i <= n)
        {
            tree[i] += v;
            i += i & -i;
        }
    }
}
