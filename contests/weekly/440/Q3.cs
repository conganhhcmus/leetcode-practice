#if DEBUG
namespace Weekly_440_Q3;
#endif

public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length;
        int[] segTree = new int[4 * n];
        Build(baskets, segTree, 0, n - 1, 1);
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            int find = Query(segTree, 0, n - 1, 1, fruits[i]);
            if (find == -1) count++;
            else Update(segTree, 0, n - 1, 1, find, 0);
        }
        return count;
    }

    private static void Build(int[] baskets, int[] segTree, int start, int end, int node)
    {
        if (start == end)
        {
            segTree[node] = baskets[start];
        }
        else
        {
            int mid = start + (end - start) / 2;
            Build(baskets, segTree, start, mid, 2 * node);
            Build(baskets, segTree, mid + 1, end, 2 * node + 1);
            segTree[node] = Math.Max(segTree[2 * node], segTree[2 * node + 1]);
        }
    }

    private static int Query(int[] segTree, int start, int end, int node, int quantity)
    {
        if (segTree[node] < quantity)
        {
            return -1;
        }
        if (start == end)
        {
            return start;
        }
        int mid = start + (end - start) / 2;

        int leftQuery = Query(segTree, start, mid, 2 * node, quantity);
        if (leftQuery != -1)
        {
            return leftQuery;
        }
        return Query(segTree, mid + 1, end, 2 * node + 1, quantity);
    }

    private static void Update(int[] segTree, int start, int end, int node, int index, int value)
    {
        if (start == end)
        {
            segTree[node] = value;
        }
        else
        {
            int mid = (start + end) / 2;
            if (index <= mid)
            {
                Update(segTree, start, mid, 2 * node, index, value);
            }
            else
            {
                Update(segTree, mid + 1, end, 2 * node + 1, index, value);
            }
            segTree[node] = Math.Max(segTree[2 * node], segTree[2 * node + 1]);
        }
    }
}