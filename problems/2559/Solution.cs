public class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        int n = words.Length;
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
        int[] prefixCount = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]))
            {
                prefixCount[i + 1] = prefixCount[i] + 1;
            }
            else
            {
                prefixCount[i + 1] = prefixCount[i];
            }
        }

        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = prefixCount[queries[i][1] + 1] - prefixCount[queries[i][0]];
        }

        return result;
    }
}