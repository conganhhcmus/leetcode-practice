public class Solution
{
    public string ConvertToTitle(int n)
    {
        string ans = "";
        while (n > 0)
        {
            n--;
            ans = (char)('A' + n % 26) + ans;
            n /= 26;
        }
        return ans;
    }
}
