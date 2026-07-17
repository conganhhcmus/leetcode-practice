public class Solution
{
    public string LexPalindromicPermutation(string s, string target)
    {
        int n = s.Length;
        int[] cnt = new int[26];
        foreach (char c in s)
        {
            cnt[c - 'a']++;
        }
        int odds = 0;
        for (int i = 0; i < 26; i++) odds += cnt[i] & 1;
        if (odds > 1) return "";
        string ans = null;
        char[] tmp = new char[n];

        Dfs(0, false);

        if (ans != null) return ans;
        return "";

        void Dfs(int pos, bool st)
        {
            if (ans != null) return;
            int m = (n + 1) / 2;
            if (pos >= m)
            {
                if (Ok()) ans = new string(tmp);
                return;
            }
            for (char c = 'a'; c <= 'z'; c++)
            {
                int idx = c - 'a';
                int l = pos, r = n - 1 - pos;
                int need = l == r ? 1 : 2;
                if (cnt[idx] < need) continue;
                if (st == false && c < target[pos]) continue;
                bool nst = st || (c > target[pos]);
                cnt[idx] -= need;
                tmp[l] = tmp[r] = c;
                Dfs(pos + 1, nst);
                cnt[idx] += need;
                if (ans != null) return;
            }
        }

        bool Ok()
        {
            for (int i = 0; i < n; i++)
            {
                if (tmp[i] > target[i]) return true;
                if (tmp[i] < target[i]) return false;
            }
            return false;
        }
    }
}
