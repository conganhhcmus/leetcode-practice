public class Solution
{
    public int RepeatedStringMatch(string a, string b)
    {
        int n = a.Length, m = b.Length;
        int k = (m + n - 1) / n;
        // repeat at least k time to build s = a.a.a...a...a with len(s) >= len(b)
        // if b start the end of a, so must extra 1 a to cover

        StringBuilder sb = new(k * n);
        sb.Insert(0, a, k);

        if (sb.ToString().Contains(b)) return k;

        sb.Append(a);
        if (sb.ToString().Contains(b)) return k + 1;

        return -1;
    }
}