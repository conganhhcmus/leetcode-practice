public class Solution
{
    public int MaxFixedPoints(int[] nums)
    {
        int n = nums.Length;
        List<(int gap, int val)> picks = [];
        for (int i = 0; i < n; i++)
        {
            int gap = i - nums[i];
            if (gap >= 0)
            {
                picks.Add((gap, nums[i]));
            }
        }
        picks.Sort((a, b) =>
        {
            if (a.gap != b.gap) return a.gap.CompareTo(b.gap);
            return a.val.CompareTo(b.val);
        });
        List<int> bests = [];
        foreach (var (_, v) in picks)
        {
            int at = FindPlace(bests, v);
            if (at == bests.Count) bests.Add(v);
            bests[at] = v;
        }
        return bests.Count;
    }

    int FindPlace(List<int> sorted, int target)
    {
        int lo = 0, hi = sorted.Count - 1, ans = sorted.Count;
        while (lo <= hi)
        {
            int mi = lo + (hi - lo) / 2;
            if (sorted[mi] >= target)
            {
                ans = mi;
                hi = mi - 1;
            }
            else
            {
                lo = mi + 1;
            }
        }
        return ans;
    }
}
