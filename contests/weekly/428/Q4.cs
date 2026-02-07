public class Solution
{
    public int MakeStringGood(string s)
    {
        const int n = 26;
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        int[] freq = new int[n + 1];
        int max = 0;
        int min = int.MaxValue;
        foreach (char c in chars)
        {
            freq[c - 'a']++;
            max = Math.Max(max, freq[c - 'a']);
        }
        for (int i = 0; i < n; i++)
        {
            if (freq[i] > 0)
            {
                min = Math.Min(min, freq[i]);
            }
        }
        int ans = int.MaxValue;
        Dictionary<string, int> memo = [];
        for (int i = min; i <= max; i++)
        {
            ans = Math.Min(ans, DP(0, 0, i, memo, freq));
        }
        return ans;
    }

    private int DP(int idx, int deleted, int target, Dictionary<string, int> memo, int[] freq)
    {
        if (idx == 26) return 0;
        var key = $"{idx}_{deleted}_{target}";
        if (memo.ContainsKey(key)) return memo[key];

        int x = freq[idx];
        int ans;
        if (x <= target)
        {
            ans = DP(idx + 1, x, target, memo, freq) + x; // delete all occurrences
            int canChange = Math.Min(deleted, target - x);
            int ansAfterChange = DP(idx + 1, 0, target, memo, freq) + target - x - canChange;// can change next letter from previous letter
            ans = Math.Min(ans, ansAfterChange);
        }
        else
        {
            ans = DP(idx + 1, x - target, target, memo, freq) + x - target; // delete all occurrences
        }

        memo[key] = ans;
        return ans;
    }
}