public class SummaryRanges
{
    UnionFind uf = new();
    HashSet<int> set = [];

    public SummaryRanges()
    {

    }

    public void AddNum(int value)
    {
        set.Add(value);
        if (set.Contains(value - 1))
        {
            uf.Union(value, value - 1);
        }
        if (set.Contains(value + 1))
        {
            uf.Union(value, value + 1);
        }
    }

    public int[][] GetIntervals()
    {
        SortedSet<int> parent = [];
        List<int[]> ans = [];
        foreach (int val in set)
        {
            parent.Add(uf.Find(val));
        }
        foreach (int val in parent)
        {
            ans.Add(uf.GetRange(val));
        }

        return ans.ToArray();
    }
}

public class UnionFind
{
    int[] parent = new int[10_001];

    int[][] map = new int[10_1001][];
    public UnionFind()
    {
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
            map[i] = [i, i];
        }
    }

    public int[] GetRange(int x)
    {
        int rootX = Find(x);
        return map[rootX];
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX == rootY) return false;
        int[] rangeX = GetRange(rootX);
        int[] rangeY = GetRange(rootY);
        if (rootX < rootY)
        {
            parent[y] = rootX;
            map[rootX] = [rangeX[0], rangeY[1]];
        }
        else
        {
            parent[x] = rootY;
            map[rootY] = [rangeY[0], rangeX[1]];
        }
        return true;
    }
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(value);
 * int[][] param_2 = obj.GetIntervals();
 */


public class Solution
{
    public List<dynamic> Execute(string[] events, int[][] values)
    {
        List<dynamic> result = [];
        SummaryRanges summaryRanges = null;

        for (int i = 0; i < events.Length; i++)
        {
            switch (events[i])
            {
                case "SummaryRanges":
                    summaryRanges = new SummaryRanges();
                    result.Add(null);
                    break;
                case "addNum":
                    summaryRanges.AddNum(values[i][0]);
                    result.Add(null);
                    break;
                case "getIntervals":
                    result.Add(summaryRanges.GetIntervals());
                    break;
            }
        }

        return result;
    }
}