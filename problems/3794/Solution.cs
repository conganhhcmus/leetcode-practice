#if DEBUG
namespace Problems_3794;
#endif

public class Solution
{
    public string ReversePrefix(string s, int k)
    {
        char[] arr = s.ToCharArray();
        for (int i = 0; i < k / 2; i++)
        {
            (arr[i], arr[k - i - 1]) = (arr[k - i - 1], arr[i]);
        }
        return new(arr);
    }
}