public class Solution
{
    public string RearrangeString(string s, char x, char y)
    {
        char[] arr = s.ToCharArray();
        for (int i = 0, j = 0; i < arr.Length; i++)
        {
            if (arr[i] == y)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                j++;
            }
        }
        return new(arr);
    }
}
