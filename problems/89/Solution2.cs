public class Solution
{
    public IList<int> GrayCode(int n)
    {
        int max = 1 << n;
        bool[] seen = new bool[max];
        List<int> ans = [];
        int curr = 0;
        ans.Add(curr);
        seen[curr] = true;
        while (ans.Count < max)
        {
            for (int i = 0; i < n; i++)
            {
                int bit = 1 << i;
                int val = curr ^ bit;
                if (!seen[val])
                {
                    curr = val;
                    ans.Add(curr);
                    seen[curr] = true;
                    break;
                }
                ;
            }
        }

        return ans;
    }
}