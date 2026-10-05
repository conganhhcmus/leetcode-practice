public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        int ans = 0;
        int cnt = 0;
        char p = '(';
        foreach (char c in s)
        {
            if (c == '(') cnt++;
            else
            {
                cnt--;
                if (p == '(') ans += 1 << cnt;
            }
            p = c;
        }
        return ans;
    }
}