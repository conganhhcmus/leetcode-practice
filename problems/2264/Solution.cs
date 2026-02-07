public class Solution
{
    public string LargestGoodInteger(string num)
    {
        int ans = -1;
        int count = 0;
        char curr = 'x';
        foreach (char d in num)
        {
            if (d == curr)
            {
                count++;
                if (count >= 3) ans = Math.Max(ans, curr - '0');
            }
            else
            {
                curr = d;
                count = 1;
            }
        }
        if (ans == -1) return "";
        return $"{ans}{ans}{ans}";
    }
}