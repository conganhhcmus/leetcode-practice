#if DEBUG
namespace Problems_13;
#endif

public class Solution
{
    public int RomanToInt(string s)
    {
        Dictionary<char, int> map = new() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
        int ans = 0;
        int prev = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            int val = map[s[i]];
            if (val >= prev) ans += val;
            else ans -= val;
            prev = val;
        }
        return ans;
    }
}