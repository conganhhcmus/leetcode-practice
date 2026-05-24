public class Solution
{
    public int[] NumberOfPairs(int[] nums1, int[] nums2, int[][] queries)
    {
        int n = nums2.Length;
        int B = (int)Math.Sqrt(n);
        int k = (n + B - 1) / B;
        Dictionary<int, int>[] freqBlock = new Dictionary<int, int>[k];
        int[] lazy = new int[k];
        for (int i = 0; i < k; i++)
        {
            freqBlock[i] = [];
        }
        for (int i = 0; i < n; i++)
        {
            freqBlock[i / B][nums2[i]] = freqBlock[i / B].GetValueOrDefault(nums2[i], 0) + 1;
        }

        List<int> ans = [];
        foreach (int[] q in queries)
        {
            if (q[0] == 1)
            {
                int l = q[1], r = q[2], v = q[3];
                int bl = l / B;
                int br = r / B;
                if (bl == br)
                {
                    for (int i = l; i <= r; i++)
                    {
                        freqBlock[bl][nums2[i]]--;
                        nums2[i] += v;
                        freqBlock[bl][nums2[i]] = freqBlock[bl].GetValueOrDefault(nums2[i], 0) + 1;
                    }
                }
                else
                {
                    int endL = (bl + 1) * B - 1;
                    int startR = br * B;
                    for (int i = l; i <= endL; i++)
                    {
                        freqBlock[bl][nums2[i]]--;
                        nums2[i] += v;
                        freqBlock[bl][nums2[i]] = freqBlock[bl].GetValueOrDefault(nums2[i], 0) + 1;
                    }
                    for (int i = startR; i <= r; i++)
                    {
                        freqBlock[br][nums2[i]]--;
                        nums2[i] += v;
                        freqBlock[br][nums2[i]] = freqBlock[br].GetValueOrDefault(nums2[i], 0) + 1;
                    }
                    for (int i = bl + 1; i < br; i++)
                    {
                        lazy[i] += v;
                    }
                }
            }
            else
            {
                int t = q[1];
                int c = 0;
                foreach (int num in nums1)
                {
                    for (int i = 0; i < k; i++)
                    {
                        int need = t - num - lazy[i];
                        c += freqBlock[i].GetValueOrDefault(need, 0);
                    }
                }

                ans.Add(c);
            }
        }
        return ans.ToArray();
    }
}
