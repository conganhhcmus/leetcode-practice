public class Solution
{
    public int MinOperations(string s1, string s2)
    {
        // 0 -> 1 need 1
        // 1 -> 0 need 2
        // 11 -> 00 need 1
        int n = s1.Length;
        int ans = 0;
        int cnt10 = 0;
        int max10 = 0;
        int cntOdd = 0;
        for (int i = 0; i < n; i++)
        {
            char c1 = s1[i], c2 = s2[i];
            if (c1 == '0' && c2 == '1') ans++;
            if (c1 == '1' && c2 == '0')
            {
                cnt10++;
                max10++;
            }
            else
            {
                if ((max10 & 1) == 1) cntOdd++;
                max10 = 0;
            }
        }
        if ((max10 & 1) == 1) cntOdd++;
        if (n == 1) return s1[0] == '1' && s2[0] == '0' ? -1 : ans;
        // ans = 
        // + sum all (0 -> 1) with cost 1
        // + sum all 111 .. 11. 111111
        // cnt10 = all 10, with cost = 1
        // 11 -> 00 cost 1, but 11 -> 10 or 01 cost 2
        // add cntOdd for make all even, so cost = (cnt10 + cntOdd)/2
        // cost add cntOdd is cntOdd
        return ans + cntOdd + (cnt10 + cntOdd) / 2;
    }
}
