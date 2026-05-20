public class Solution
{
    public string LexSmallestAfterDeletion(string s)
    {
        int n = s.Length;
        int[] count = new int[26];
        for (int i = 0; i < n; i++)
        {
            count[s[i] - 'a']++;
        }
        char[] stack = new char[n];
        int t = -1;
        for (int i = 0; i < n; i++)
        {
            while (t >= 0 && stack[t] > s[i] && count[stack[t] - 'a'] > 1)
            {
                count[stack[t--] - 'a']--;
            }
            stack[++t] = s[i];
        }

        while (count[stack[t] - 'a'] > 1) count[stack[t--] - 'a']--;

        return new string(stack, 0, t + 1);
    }
}
