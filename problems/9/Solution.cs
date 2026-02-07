public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        int reverse = 0;
        int temp = x;
        while (temp > 0)
        {
            int digit = temp % 10;
            temp /= 10;
            reverse = reverse * 10 + digit;
        }

        return x == reverse;
    }
}