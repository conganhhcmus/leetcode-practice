public class Solution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        int qLen = queries.Length, hLen = heights.Length;
        // Build Seqment tree
        int[] tree = new int[4 * hLen + 1];
        int start_index = 1;
        void Build(int idx, int l, int r)
        {
            if (l == r)
            {
                tree[idx] = heights[l];
                return;
            }

            int mid = l + (r - l) / 2;

            Build(2 * idx, l, mid);
            Build(2 * idx + 1, mid + 1, r);

            tree[idx] = Math.Max(tree[2 * idx], tree[2 * idx + 1]);
        }

        int Query(int idx, int l, int r, int qL, int qR, int minHeight)
        {
            if (l > qR || r < qL) return int.MaxValue;
            if (tree[idx] < minHeight) return int.MaxValue;

            if (l == r) return l;

            int mid = l + (r - l) / 2;
            int ans = Query(2 * idx, l, mid, qL, qR, minHeight);
            if (ans != int.MaxValue) return ans;
            return Query(2 * idx + 1, mid + 1, r, qL, qR, minHeight);
        }

        Build(start_index, 0, hLen - 1);

        int[] ans = new int[qLen];
        for (int i = 0; i < qLen; i++)
        {
            int a = queries[i][0], b = queries[i][1];
            if (a < b && heights[a] < heights[b])
            {
                ans[i] = b;
            }
            else if (a > b && heights[a] > heights[b])
            {
                ans[i] = a;
            }
            else if (a == b)
            {
                ans[i] = a;
            }
            else
            {
                int l = Math.Max(a, b), r = hLen - 1;
                int minHeight = Math.Max(heights[a], heights[b]) + 1;
                int res = Query(start_index, 0, hLen - 1, l, r, minHeight);
                if (res == int.MaxValue) ans[i] = -1;
                else ans[i] = res;
            }
        }

        return ans;
    }
}