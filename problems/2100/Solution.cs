public class Solution
{
    public IList<int> GoodDaysToRobBank(int[] security, int time)
    {
        int n = security.Length;
        int[] prefix = new int[n];
        prefix[0] = 0;
        for (int i = 1; i < n; i++)
        {
            if (security[i - 1] >= security[i])
            {
                prefix[i] = prefix[i - 1];
            }
            else
            {
                prefix[i] = i;
            }
        }

        int[] suffix = new int[n];
        suffix[n - 1] = n - 1;
        for (int i = n - 2; i >= 0; i--)
        {
            if (security[i] <= security[i + 1])
            {
                suffix[i] = suffix[i + 1];
            }
            else
            {
                suffix[i] = i;
            }
        }

        IList<int> ret = [];
        for (int i = 0; i < n; i++)
        {
            int left = prefix[i], right = suffix[i];
            if (Math.Abs(left - i) >= time && Math.Abs(right - i) >= time) ret.Add(i);
        }
        return ret;
    }
}