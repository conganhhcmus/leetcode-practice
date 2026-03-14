public class Solution
{
    public string GetHappyString(int n, int k)
    {
        int total = 3 * (1 << (n - 1));
        if (k > total) return "";
        string ans = "";
        char prev = '#';
        for (int i = 0; i < n; i++)
        {
            int count = 1 << (n - i - 1);
            for (char c = 'a'; c <= 'c'; c++)
            {
                if (c == prev) continue;
                if (k > count)
                {
                    k -= count;
                }
                else
                {
                    ans += c;
                    prev = c;
                    break;
                }
            }
        }
        return ans;
    }
}