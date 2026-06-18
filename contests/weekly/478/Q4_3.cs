public class Solution
{
    public long[] MinOperations(int[] nums, int k, int[][] queries)
    {
        int n = nums.Length;
        int m = queries.Length;
        int[] d = new int[n];
        for (int i = 1; i < n; i++)
        {
            d[i] = d[i - 1] + ((nums[i] - nums[i - 1]) % k == 0 ? 0 : 1);
        }
        long[] uniq = [.. nums.ToHashSet()];
        Array.Sort(uniq);
        int MAX = (n + 5) * 20;
        int[] L = new int[MAX];
        int[] R = new int[MAX];
        int[] c = new int[MAX];
        long[] s = new long[MAX];
        int[] rt = new int[n + 1];
        int prt = 1;
        int M = uniq.Length;
        for (int i = 0; i < n; i++)
        {
            int id = Array.BinarySearch(uniq, nums[i]);
            rt[i + 1] = Update(rt[i], 0, M - 1, id, nums[i]);
        }

        long[] ans = new long[m];
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            int diff = d[r] - (l == 0 ? 0 : d[l]);
            if (diff == 0)
            {
                int len = r - l + 1;
                if (len == 1) continue;
                int a = rt[l], b = rt[r + 1];
                int pos = (len + 1) / 2;
                int midId = Kth(a, b, 0, M - 1, pos);
                long median = uniq[midId];
                long totSum = Sum(a, b, 0, M - 1, 0, M - 1);

                long leftSum = Sum(a, b, 0, M - 1, 0, midId);
                int leftCnt = Cnt(a, b, 0, M - 1, 0, midId);

                int rightCnt = len - leftCnt;
                long rightSum = totSum - leftSum;
                long cost = median * leftCnt - leftSum + rightSum - median * rightCnt;
                ans[i] = cost / k;
            }
            else
            {
                ans[i] = -1;
            }
        }
        return ans;

        int Update(int prev, int l, int r, int pos, int val)
        {
            int cur = prt++;
            c[cur] = c[prev] + 1;
            s[cur] = s[prev] + val;
            if (l != r)
            {
                int m = (l + r) >> 1;
                if (pos <= m)
                {
                    L[cur] = Update(L[prev], l, m, pos, val);
                    R[cur] = R[prev];
                }
                else
                {
                    L[cur] = L[prev];
                    R[cur] = Update(R[prev], m + 1, r, pos, val);
                }
            }
            return cur;
        }

        int Kth(int a, int b, int l, int r, int k)
        {
            if (l == r) return l;
            int m = (l + r) >> 1;
            int cLeft = c[L[b]] - c[L[a]];
            if (k <= cLeft) return Kth(L[a], L[b], l, m, k);
            return Kth(R[a], R[b], m + 1, r, k - cLeft);
        }

        long Sum(int a, int b, int l, int r, int ql, int qr)
        {
            if (ql > r || qr < l) return 0;
            if (ql <= l && qr >= r) return s[b] - s[a];
            int m = (l + r) >> 1;
            long res = 0;
            res += Sum(L[a], L[b], l, m, ql, qr);
            res += Sum(R[a], R[b], m + 1, r, ql, qr);
            return res;
        }

        int Cnt(int a, int b, int l, int r, int ql, int qr)
        {
            if (ql > r || qr < l) return 0;
            if (ql <= l && qr >= r) return c[b] - c[a];
            int m = (l + r) >> 1;
            int res = 0;
            res += Cnt(L[a], L[b], l, m, ql, qr);
            res += Cnt(R[a], R[b], m + 1, r, ql, qr);
            return res;
        }
    }
}
