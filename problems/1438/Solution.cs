#if DEBUG
namespace Problems_1438;
#endif

public class Solution
{
    public int LongestSubarray(int[] nums, int limit)
    {
        int n = nums.Length;
        int ret = 1;
        Node[] segTree = new Node[4 * n];
        Build(segTree, nums, 1, 0, n - 1);
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            Node curr = Query(segTree, 1, 0, n - 1, i, j);
            while (j < n && Math.Abs(curr.Min - curr.Max) <= limit)
            {
                j++;
                curr = Query(segTree, 1, 0, n - 1, i, j);
            }

            ret = Math.Max(ret, j - i);
        }
        return ret;
    }

    public record Node(int Min, int Max);

    void Build(Node[] segTree, int[] nums, int node, int start, int end)
    {
        if (start == end)
        {
            segTree[node] = new(nums[start], nums[start]);
            return;
        }
        int mid = start + (end - start) / 2;
        Build(segTree, nums, 2 * node, start, mid);
        Build(segTree, nums, 2 * node + 1, mid + 1, end);
        int min = Math.Min(segTree[2 * node].Min, segTree[2 * node + 1].Min);
        int max = Math.Max(segTree[2 * node].Max, segTree[2 * node + 1].Max);
        segTree[node] = new(min, max);
    }

    Node Query(Node[] segTree, int node, int start, int end, int left, int right)
    {
        if (left > end || right < start) return new(int.MaxValue / 2, int.MinValue / 2);
        if (left <= start && right >= end) return segTree[node];
        int mid = start + (end - start) / 2;
        Node leftVal = Query(segTree, 2 * node, start, mid, left, right);
        Node rightVal = Query(segTree, 2 * node + 1, mid + 1, end, left, right);
        int min = Math.Min(leftVal.Min, rightVal.Min);
        int max = Math.Max(leftVal.Max, rightVal.Max);
        return new(min, max);
    }
}