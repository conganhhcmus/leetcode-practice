public class Solution
{
    public IList<int> FindGoodIntegers(int n)
    {
        List<int> ans = [];
        Dictionary<int, int> freq = [];
        for (int i = 1; i <= 1000; i++)
        {
            int a = i * i * i;
            if (a > n) break;
            for (int j = i; j <= 1000; j++)
            {
                int b = j * j * j;
                if (a + b > n) break;
                freq[a + b] = freq.GetValueOrDefault(a + b, 0) + 1;
                if (freq[a + b] == 2) ans.Add(a + b);
            }
        }
        ans.Sort();
        return ans;
    }
}