public class Solution
{
    public string LicenseKeyFormatting(string s, int k)
    {
        int n = s.Length;
        char[] buffer = new char[n + (n - 1) / k];
        int size = 0;
        int pos = buffer.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == '-') continue;
            if (size == k)
            {
                size = 0;
                buffer[--pos] = '-';
            }
            buffer[--pos] = s[i] > 96 ? (char)(s[i] - 32) : s[i];
            size++;
        }

        return new string(buffer, pos, buffer.Length - pos);
    }
}