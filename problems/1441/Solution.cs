public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        List<string> res = [];
        int idx = 0;
        for (int i = 1; i <= n; i++)
        {
            if (idx == target.Length) break;
            res.Add("Push");
            if (i == target[idx])
            {
                idx++;
                continue;
            }
            res.Add("Pop");
        }
        return res;
    }
}