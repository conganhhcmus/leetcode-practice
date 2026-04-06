public class Solution
{
    public string MapWordWeights(string[] words, int[] weights)
    {
        int Sum(string word)
        {
            int ans = 0;
            foreach (char c in word)
            {
                ans += weights[c - 'a'];
            }
            return ans % 26;
        }
        StringBuilder sb = new();
        foreach (string word in words)
        {
            int sum = Sum(word);
            sb.Append((char)('z' - sum));
        }

        return sb.ToString();
    }
}