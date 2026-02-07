public class Solution
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        int n = groups.Length;
        List<string> ans = [];
        int last = -1;
        for (int i = 0; i < n; i++)
        {
            if (last == groups[i]) continue;
            ans.Add(words[i]);
            last = groups[i];
        }
        return ans;
    }
}