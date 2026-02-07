public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int n = bank.Length;
        int[] count = new int[n];
        for (int i = 0; i < n; i++)
        {
            foreach (char c in bank[i])
            {
                if (c == '1')
                {
                    count[i]++;
                }
            }
        }
        int ans = 0;
        int prev = 0;
        for (int i = 0; i < n; i++)
        {
            if (count[i] == 0) continue;
            ans += prev * count[i];
            prev = count[i];
        }

        return ans;
    }
}