public class Solution
{
    public int FindTheLongestSubstring(string s)
    {
        // a: 'a' - 'a' = 0
        // e: 'e' - 'a' = 4
        // i: 'i' - 'a' = 8
        // o: 'o' - 'a' = 14
        //u: 'u' - 'a' = 20
        //=> vowelsBitMask = 100000100000100010001 -> 1065233 (int)
        //                   u     o     i   e   a
        int vowelsBitMask = 1065233;

        // for each s[i], we represent the character as a bitmask.
        // s[i] = 'a' => b[i] = 00..01 (26 bits)
        // s[i] = 'b' => b[i] = 00..10 (26 bits)
        // ....
        // s[i] = 'z' => b[i] = 10...0 (26 bits)
        // b[i] = 1 << (s[i] - 'a')
        // dp[i] = b[0] ^ b[1] ^...^b[i]

        int[] dp = new int[s.Length];
        Array.Fill(dp, 0);
        dp[0] = 1 << (s[0] - 'a');
        for (int i = 1; i < s.Length; i++)
        {
            dp[i] = dp[i - 1] ^ (1 << (s[i] - 'a'));
        }

        // s = "aabbe", n = s.Length = 5
        // dp = [00001,00000,00010,00000,10000]
        // "a"      : 00001
        // "aa"     : 00000
        // "aab"    : 00010
        // "aabb"   : 00000
        // "aabbe"  : 10000
        // vowelsBitMask = "100000100000100010001"
        // 1. len = 5
        //    start = 0, end = 4, substring = "aabbe"
        //    bitMask = start == 0 ? dp[end] : dp[start - 1] ^ dp[end] 
        //.           = dp[4] = 10000
        //    bitMask & vowelsBitMask = 10000 & 100000100000100010001 = 10000 != 0
        // 2. len = 4
        //    start = 0, end = 3, substring = "aabb"
        //    bitMask = start == 0 ? dp[end] : dp[start - 1] ^ dp[end]
        //.           = dp[3] = 00000
        //    bitMask & vowelsBitMask = 00000 & 100000100000100010001 = 00000 == 0
        //    => ans = len = 4

        for (int len = s.Length; len > 0; len--)
        {
            for (int start = 0; start + len - 1 < s.Length; start++)
            {
                int end = start + len - 1;
                var bitMask = start == 0 ? dp[end] : dp[start - 1] ^ dp[end];
                if ((bitMask & vowelsBitMask) == 0)
                {
                    return len;
                }
            }
        }

        return 0;
    }
}