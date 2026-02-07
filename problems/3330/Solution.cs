public class Solution
{
    public int PossibleStringCount(string word)
    {
        int n = word.Length;
        int ans = 1;
        for (int i = 1; i < n; i++)
        {
            if (word[i] == word[i - 1])
            {
                ans++;
            }
        }
        return ans;
    }
}