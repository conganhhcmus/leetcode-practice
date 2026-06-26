public class Solution
{
    public int TotalWaviness(int num1, int num2)
    {
        int ans = 0;
        for (int i = num1; i <= num2; i++)
        {
            ans += Count(i);
        }
        return ans;

        int Count(int n)
        {
            int cnt = 0;
            string str = n.ToString();
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i] > str[i - 1] && str[i] > str[i + 1]) cnt++;
                if (str[i] < str[i - 1] && str[i] < str[i + 1]) cnt++;
            }
            return cnt;
        }
    }
}
