public class Solution {
    public bool HasAllCodes(string s, int k) {
        int n = s.Length;
        if (k > n) return false;
        int max = 1 << k;
        int cur = 0;
        HashSet<int> set = [];
        for(int i = 0;i<k;i++){
            cur = (cur << 1) | (s[i] - '0');
        }
        set.Add(cur);
        for(int i = k;i<n;i++){
            cur = (cur << 1) | (s[i] - '0');
            cur &= max-1;
            set.Add(cur);
        }
        return set.Count == max;
    }
}