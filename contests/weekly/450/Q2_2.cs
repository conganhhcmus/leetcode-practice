public class Solution
{
    public int MinSwaps(int[] nums)
    {
        int n = nums.Length;
        int[] clone = new int[n];
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++)
        {
            map[nums[i]] = i;
        }
        Array.Copy(nums, clone, n);
        Array.Sort(clone, (a, b) =>
        {
            int sum1 = SumDigit(a);
            int sum2 = SumDigit(b);
            if (sum1 == sum2) return a - b;
            return sum1 - sum2;
        });
        int ret = n;

        UnionFind uf = new(n);
        for (int i = 0; i < n; i++)
        {
            if (clone[i] != nums[i])
            {
                uf.Union(map[nums[i]], map[clone[i]]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (uf.Find(i) == i) ret--;
        }

        return ret;
    }

    int SumDigit(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }


}

public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] rank;

    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
    }

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return false;
        if (rank[rootX] <= rank[rootY])
        {
            parent[rootX] = rootY;
            rank[rootY]++;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}