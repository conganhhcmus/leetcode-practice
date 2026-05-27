public class Solution
{
    public string LargestEven(string s)
    {
        StringBuilder sb = new(s);
        int del = 0;
        for (int i = sb.Length - 1; i >= 0; i--)
        {
            if (s[i] == '2') break;
            del++;
        }
        sb.Length -= del;
        return sb.ToString();
    }
}
