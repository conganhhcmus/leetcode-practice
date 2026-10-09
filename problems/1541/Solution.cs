public class Solution
{
    public int MinInsertions(string s)
    {
        int n = s.Length;
        int ans = 0;
        int leftCnt = 0;
        int idx = 0;
        while (idx < n)
        {
            char c = s[idx];
            if (c == '(')
            {
                leftCnt++;
                idx++;
            }
            else
            {
                if (leftCnt > 0) leftCnt--;
                else ans++;
                if (idx < n - 1 && s[idx + 1] == ')')
                {
                    idx += 2;
                }
                else
                {
                    ans++;
                    idx++;
                }
            }
        }
        ans += leftCnt * 2;
        return ans;
    }
}