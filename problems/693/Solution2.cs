public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        int prev = n % 2;
        n /= 2;
        while (n > 0)
        {
            int curr = n % 2;
            if (prev == curr) return false;
            n /= 2;
            prev = curr;
        }
        return true;
    }
}