public class Solution
{
    public int MaximumWidth(int[] planks)
    {
        int n = planks.Length;
        int ans = 0;
        // 1 2 3 4 5 7
        Dictionary<int, int> freq = [];
        for (int i = 0; i < n; i++)
        {
            freq[planks[i]] = freq.GetValueOrDefault(planks[i], 0) + 1;
        }
        int[] vals = [.. freq.Keys];
        Array.Sort(vals);
        Dictionary<int, int> cnt = [];
        for (int i = 0; i < vals.Length; i++)
        {
            int a = freq.GetValueOrDefault(vals[i], 0);
            cnt[vals[i]] = cnt.GetValueOrDefault(vals[i], 0) + a;
            cnt[2 * vals[i]] = cnt.GetValueOrDefault(2 * vals[i], 0) + a / 2;

            for (int j = i + 1; j < vals.Length; j++)
            {
                int t = vals[i] + vals[j];
                cnt[t] = cnt.GetValueOrDefault(t, 0) + Math.Min(freq[vals[i]], freq[vals[j]]);
            }
        }
        foreach (int val in cnt.Values)
        {
            if (ans < val) ans = val;
        }

        return ans;
    }
}
