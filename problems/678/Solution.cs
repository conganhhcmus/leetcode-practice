public class Solution
{
    public bool CheckValidString(string s)
    {
        int n = s.Length;
        // keep open >= close
        Dictionary<(int, int), bool> memo = [];
        return DP(0, 0);
        bool DP(int pos, int bal)
        {
            if (bal < 0) return false;
            if (pos >= n) return bal == 0;
            var key = (pos, bal);
            if (memo.TryGetValue(key, out bool cache)) return cache;
            bool ans = false;
            if (s[pos] == '(') ans |= DP(pos + 1, bal + 1);
            if (s[pos] == ')') ans |= DP(pos + 1, bal - 1);
            if (s[pos] == '*')
            {
                ans |= DP(pos + 1, bal) || DP(pos + 1, bal + 1) || DP(pos + 1, bal - 1);
            }
            return memo[key] = ans;
        }
    }
}