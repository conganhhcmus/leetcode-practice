public class Solution
{
    public bool IsScramble(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int n = s1.Length;
        Dictionary<(int, int, int), bool> memo = [];
        return Ok(0, 0, n);

        bool Ok(int i, int j, int l)
        {
            var key = (i, j, l);
            if (memo.TryGetValue(key, out bool cache)) return cache;
            bool isSame = true;
            for (int k = 0; k < l; k++)
            {
                if (s1[i + k] != s2[j + k])
                {
                    isSame = false;
                    break;
                }
            }
            if (isSame) return memo[key] = true;

            int[] cnt = new int[26];
            for (int k = 0; k < l; k++)
            {
                cnt[s1[i + k] - 'a']++;
                cnt[s2[j + k] - 'a']--;
            }
            for (int k = 0; k < 26; k++)
            {
                if (cnt[k] != 0) return memo[key] = false;
            }

            for (int k = 1; k < l; k++)
            {
                // no swap, left = left, right = right
                if (Ok(i, j, k) && Ok(i + k, j + k, l - k)) return memo[key] = true;

                // swap, left = right, right = left
                if (Ok(i, j + l - k, k) && Ok(i + k, j, k)) return memo[key] = true;
            }

            return memo[key] = false;
        }
    }
}
