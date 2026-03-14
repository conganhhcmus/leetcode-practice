public class Solution
{
    public string GetPermutation(int n, int k)
    {
        string ans = "";
        int[] fact = new int[n + 1];
        bool[] seen = new bool[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = fact[i - 1] * i;
        }
        for (int i = 0; i < n; i++)
        {
            int count = fact[n - i - 1];
            for (int d = 1; d <= n; d++)
            {
                if (seen[d]) continue;
                if (k > count)
                {
                    k -= count;
                }
                else
                {
                    ans += (char)('0' + d);
                    seen[d] = true;
                    break;
                }
            }
        }
        return ans;
    }
}