public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        string numStr = x.ToString();
        int n = numStr.Length;
        for (int i = 0; i <= n / 2; i++)
        {
            if (numStr[i] != numStr[n - 1 - i]) return false;
        }
        return true;
    }
}