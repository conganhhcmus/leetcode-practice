public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        List<string> ans = [];
        foreach (string q in queries)
        {
            foreach (string d in dictionary)
            {
                int diff = 0;
                for (int i = 0; i < q.Length && diff <= 2; i++)
                {
                    if (q[i] != d[i]) diff++;
                }
                if (diff <= 2)
                {
                    ans.Add(q);
                    break;
                }
            }
        }

        return ans;
    }
}
