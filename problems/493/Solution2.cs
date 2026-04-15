public class Solution
{
    public int ReversePairs(int[] nums)
    {
        HashSet<long> set = [];
        foreach (int num in nums)
        {
            set.Add(num);
            set.Add(2L * num);
        }
        Dictionary<long, int> map = [];
        long[] all = set.ToArray();
        int n = all.Length;
        Array.Sort(all);
        for (int i = 0; i < n; i++)
        {
            map[all[i]] = i + 1;
        }
        Fenwich tree = new(n);
        int count = 0;
        int m = nums.Length;
        for (int i = m - 1; i >= 0; i--)
        {
            long val = nums[i];
            count += tree.Query(map[val] - 1);
            tree.Update(map[2 * val], 1);
        }

        return count;
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
