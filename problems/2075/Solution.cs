public class Solution
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        int n = encodedText.Length;
        int cols = n / rows;
        char[] ans = new char[n];
        int idx = 0;
        for (int i = 0; i < cols; i++)
        {
            int r = 0, c = i;
            while (r < rows && c < cols)
            {
                ans[idx++] = encodedText[r * cols + c];
                r++;
                c++;
            }
        }
        while (idx - 1 >= 0 && (ans[idx - 1] == ' ')) idx--;
        return new string(ans, 0, idx);
    }
}