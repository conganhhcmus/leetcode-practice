#if DEBUG
namespace Contests_432_Q4;
#endif

public class Solution
{
    // // O(n)
    // public long CountNonDecreasingSubarrays(int[] nums, long k)
    // {
    //     int n = nums.Length;
    //     long ans = 0;
    //     Array.Reverse(nums);
    //     LinkedList<int> dq = new();
    //     for (int i = 0, j = 0; j < n; j++)
    //     {
    //         while (dq.Count > 0 && nums[dq.Last.Value] < nums[j])
    //         {
    //             int r = dq.Last.Value;
    //             dq.RemoveLast();
    //             int l = dq.Count > 0 ? dq.Last.Value : i - 1;
    //             k -= 1L * (r - l) * (nums[j] - nums[r]);
    //         }
    //         dq.AddLast(j);
    //         while (k < 0)
    //         {
    //             k += nums[dq.First.Value] - nums[i];
    //             if (dq.First.Value == i)
    //             {
    //                 dq.RemoveFirst();
    //             }
    //             i++;
    //         }
    //         ans += j - i + 1;
    //     }

    //     return ans;
    // }

    // // O(n log n)

    public long CountNonDecreasingSubarrays(int[] nums, long k)
    {
        long ans = 1;
        int n = nums.Length;
        SegmentTree st = new(new long[n]);
        int right = n - 1;
        st.Update(n - 1, n - 1, nums[n - 1]);
        for (int i = n - 2; i >= 0; i--)
        {
            st.Update(i, i, nums[i]);
            if (nums[i] <= nums[i + 1])
            {
                ans += right - i + 1;
                continue;
            }
            int l = i + 1, r = right, f = i + 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (st.Query(m, m) < nums[i])
                {
                    f = m;
                    l = m + 1;
                }
                else r = m - 1;
            }
            long sum = st.Query(i, f);
            long d = nums[i] * (f - i + 1L) - sum;
            st.Update(i, f, nums[i]);
            k -= d;
            while (k < 0)
            {
                k += st.Query(right, right) - nums[right];
                right--;
            }

            ans += right - i + 1;
        }

        return ans;
    }
}


public class SegmentTree
{
    readonly long[] data;
    readonly long[] tree;
    readonly long[] lazy;
    readonly int len;
    public SegmentTree(long[] nums)
    {
        len = nums.Length;
        data = new long[len];
        Array.Copy(nums, data, len);
        tree = new long[4 * len + 1];
        lazy = new long[4 * len + 1];
        Build(1, 0, len - 1);
    }

    // O(n * log n)
    private void Build(int node, int start, int end)
    {
        if (start == end)
        {
            tree[node] = data[start];
            return;
        }
        int mid = start + (end - start) / 2;
        Build(2 * node, start, mid);
        Build(2 * node + 1, mid + 1, end);
        PushUp(node);
    }

    // O(log n)
    public long Query(int st, int ed)
    {
        return Query(1, 0, len - 1, st, ed);
    }
    private long Query(int node, int start, int end, int qStart, int qEnd)
    {
        // if (end < qStart || start > qEnd) return int.MinValue; // return min value;
        if (end < qStart || start > qEnd) return 0; // return sum value = 0;
        if (qStart <= start && qEnd >= end) return tree[node];

        int mid = start + (end - start) / 2;
        PushDown(node, start, end, mid);

        long ans = 0;
        if (qStart <= mid)
        {
            ans += Query(2 * node, start, mid, qStart, qEnd);
        }

        if (qEnd > mid)
        {
            ans += Query(2 * node + 1, mid + 1, end, qStart, qEnd);
        }

        return ans;
    }

    // O(log n)
    public void Update(int st, int ed, long val)
    {
        Update(1, 0, len - 1, st, ed, val);
    }
    private void Update(int node, int start, int end, int uStart, int uEnd, long value) // update increment or decrement value from l->r
    {
        if (uStart > end || uEnd < start) return;
        if (uStart <= start && uEnd >= end)
        {
            tree[node] = (end - start + 1L) * value;
            lazy[node] = value;
            return;
        }

        int mid = start + (end - start) / 2;
        PushDown(node, start, end, mid);
        Update(2 * node, start, mid, uStart, uEnd, value);
        Update(2 * node + 1, mid + 1, end, uStart, uEnd, value);
        PushUp(node);
    }

    private void PushDown(int node, int start, int end, int mid)
    {
        if (lazy[node] != 0)
        {
            tree[2 * node] = (mid - start + 1L) * lazy[node];
            tree[2 * node + 1] = (end - mid) * lazy[node];
            lazy[2 * node] = lazy[node];
            lazy[2 * node + 1] = lazy[node];
            lazy[node] = 0;
        }
    }

    private void PushUp(int node)
    {
        tree[node] = tree[2 * node] + tree[2 * node + 1]; // sum value
    }
}