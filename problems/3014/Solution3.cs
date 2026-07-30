public class Solution
{
    public int MinimumPushes(string word)
    {
        int n = word.Length;
        int div = n / 8;
        int mod = n % 8;
        return mod * (div + 1) + 4 * div * (div + 1);
    }
}
