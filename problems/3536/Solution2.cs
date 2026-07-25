public class Solution
{
    public int MaxProduct(int n)
    {
        string s = n.ToString();
        int ans = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                int p = (s[i] - '0') * (s[j] - '0');
                if (ans < p) ans = p;
            }
        }
        return ans;
    }
}
