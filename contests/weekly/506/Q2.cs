public class Solution
{
    public int GetLength(int[] nums)
    {
        int n = nums.Length;
        int ans = 1;
        for (int l = 0; l < n; l++)
        {
            Dictionary<int, int> freq = [];
            Dictionary<int, int> freqCnt = [];
            for (int r = l; r < n; r++)
            {
                int x = nums[r];
                freq.TryGetValue(x, out int oldFreq);
                if (oldFreq > 0)
                {
                    freqCnt[oldFreq]--;
                    if (freqCnt[oldFreq] == 0) freqCnt.Remove(oldFreq);
                }
                int newFreq = oldFreq + 1;
                freq[x] = newFreq;
                freqCnt.TryGetValue(newFreq, out int c);
                freqCnt[newFreq] = c + 1;
                bool ok = false;
                if (freq.Count == 1) ok = true;
                else if (freqCnt.Count == 2)
                {
                    int mn = int.MaxValue;
                    int mx = 0;
                    foreach (var kv in freqCnt)
                    {
                        mn = Math.Min(mn, kv.Key);
                        mx = Math.Max(mx, kv.Key);
                    }
                    if (mx == 2 * mn) ok = true;
                }
                if (ok) ans = Math.Max(ans, r - l + 1);
            }
        }
        return ans;
    }
}
