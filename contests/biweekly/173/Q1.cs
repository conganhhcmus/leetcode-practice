public class Solution
{
    public string ReversePrefix(string s, int k)
    {
        char[] a = s.ToCharArray();
        for (int i = 0; i < k / 2; i++)
        {
            (a[i], a[k - i - 1]) = (a[k - i - 1], a[i]);
        }

        return new(a);
    }
}
