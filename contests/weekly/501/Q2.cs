public class Solution
{
    public int[] CountWordOccurrences(string[] chunks, string[] queries)
    {
        StringBuilder sb = new();
        foreach (string ch in chunks) sb.Append(ch);
        int n = sb.Length;
        StringBuilder word = new();
        Dictionary<string, int> count = [];
        for (int i = 0; i < n; i++)
        {
            if ('a' <= sb[i] && 'z' >= sb[i] || IsValidHyphen(i))
            {
                word.Append(sb[i]);
            }
            else
            {
                string w = word.ToString();
                count[w] = count.GetValueOrDefault(w, 0) + 1;
                word.Length = 0;
            }
        }
        if (word.Length > 0)
        {
            string w = word.ToString();
            count[w] = count.GetValueOrDefault(w, 0) + 1;
            word.Length = 0;
        }
        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            ans[i] = count.GetValueOrDefault(queries[i]);
        }
        return ans;

        bool IsValidHyphen(int i)
        {
            if (i > 0 && i < n - 1)
            {
                return sb[i] == '-' && 'a' <= sb[i - 1] && 'z' >= sb[i - 1] && 'a' <= sb[i + 1] && 'z' >= sb[i + 1];
            }
            return false;
        }
    }
}
