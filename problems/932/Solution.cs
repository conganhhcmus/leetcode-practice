public class Solution
{
    public int[] BeautifulArray(int n)
    {
        List<int> ans = [1];
        while (ans.Count < n)
        {
            List<int> odd = [];
            List<int> even = [];
            foreach (int x in ans)
            {
                if (2 * x - 1 <= n) odd.Add(2 * x - 1);
                if (2 * x <= n) even.Add(2 * x);
            }
            ans.Clear();
            ans.AddRange(odd);
            ans.AddRange(even);
        }

        return ans.ToArray();
    }
}