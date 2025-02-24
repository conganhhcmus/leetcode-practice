#if DEBUG
namespace Problems_1371_2;
#endif

public class Solution
{
    public int FindTheLongestSubstring(string s)
    {
        int n = s.Length;
        int[] charMap = new int[26];
        charMap['a' - 'a'] = 1;
        charMap['e' - 'a'] = 2;
        charMap['i' - 'a'] = 4;
        charMap['o' - 'a'] = 8;
        charMap['u' - 'a'] = 16;
        int[] map = new int[32]; // max value is set all bits 11111 ~ 31 (int)
        Array.Fill(map, -1);
        int prefixXor = 0;
        int maxLength = 0;
        for (int i = 0; i < n; i++)
        {
            prefixXor ^= charMap[s[i] - 'a'];
            if (prefixXor != 0 && map[prefixXor] == -1) map[prefixXor] = i;
            maxLength = Math.Max(maxLength, i - map[prefixXor]);
        }

        return maxLength;
    }
}