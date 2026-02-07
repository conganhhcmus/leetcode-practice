public class Solution
{
    public int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        int ans = 0;
        Dictionary<int, int> freq = [];
        for (int i = 0, j = 0; i < n; i++)
        {
            freq[fruits[i]] = freq.GetValueOrDefault(fruits[i], 0) + 1;
            while (j < i && freq.Keys.Count > 2)
            {
                if (freq[fruits[j]] == 1)
                {
                    freq.Remove(fruits[j]);
                }
                else
                {
                    freq[fruits[j]]--;
                }

                j++;
            }
            ans = Math.Max(ans, i - j + 1);
        }
        return ans;
    }
}