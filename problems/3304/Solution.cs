public class Solution
{
    public char KthCharacter(int k)
    {
        int n = (int)Math.Log2(k) + 1;
        StringBuilder sb = new("a");
        for (int i = 0; i < n; i++)
        {
            int m = sb.Length;
            for (int j = 0; j < m; j++)
            {
                sb.Append(NextChar(sb[j]));
            }
        }

        return sb[k - 1];
    }

    char NextChar(char c)
    {
        int diff = c - 'a';
        diff = (diff + 1) % 26;
        return (char)('a' + diff);
    }
}