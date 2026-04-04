public class Solution
{
    public int RepeatedStringMatch(string a, string b)
    {
        int n = a.Length, m = b.Length;
        for (int i = 0; i < n; i++)
        {
            if (a[i] != b[0]) continue;
            bool isOk = true;
            for (int j = 0; j < m; j++)
            {
                int idx = (i + j) % n;
                if (a[idx] != b[j])
                {
                    isOk = false;
                    break;
                }
            }
            if (isOk) return (i + m + n - 1) / n;
        }
        return -1;
    }
}