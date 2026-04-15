public class Solution
{
    public long SumScores(string s)
    {
        int n = s.Length;
        int[] z = new int[n];

        int l = 0,
            r = 0;
        z[0] = n;
        for (int i = 1; i < n; i++)
        {
            if (i <= r)
            {
                z[i] = Math.Min(r - i + 1, z[i - l]);
            }

            while (i + z[i] < n && s[z[i]] == s[i + z[i]])
            {
                z[i]++;
            }

            if (i + z[i] - 1 > r)
            {
                l = i;
                r = i + z[i] - 1;
            }
        }

        long sum = 0;
        foreach (var v in z)
            sum += v;

        return sum;
    }
}
