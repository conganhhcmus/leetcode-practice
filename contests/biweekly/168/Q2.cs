public class Solution
{
    public string MaxSumOfSquares(int num, int sum)
    {
        if (num * 9 < sum) return "";
        char[] ans = new char[num];
        Array.Fill(ans, '0');
        // a ^ 2 + b ^ 2 = (a + b) ^ 2 - xxx
        // a ^ 2 +  b^2 <= (a + b) ^ 2
        for (int i = 0; i < num; i++)
        {
            int d = Math.Min(sum, 9);
            ans[i] = (char)(d + '0');
            sum -= d;
        }
        return new string(ans);
    }
}
