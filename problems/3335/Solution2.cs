public class Solution
{
    int mod = (int)1e9 + 7;

    public int LengthAfterTransformations(string s, int t)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        for (int i = 0; i < t; i++)
        {
            int[] curr = new int[26];
            curr[0] = count[25];
            curr[1] = (count[25] + count[0]) % mod;
            for (int j = 2; j < 26; j++)
            {
                curr[j] = count[j - 1];
            }
            count = curr;
        }

        int ret = 0;
        for (int i = 0; i < 26; i++)
        {
            ret = (ret + count[i]) % mod;
        }
        return ret;
    }
}