#if DEBUG
namespace Problems_2697;
#endif

public class Solution
{
    public string MakeSmallestPalindrome(string s)
    {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        int l = 0, r = n - 1;
        while (l < r)
        {
            if (arr[l] == arr[r])
            {
                l++;
                r--;
            }
            else
            {
                char replace = arr[l] < arr[r] ? arr[l] : arr[r];
                arr[l] = arr[r] = replace;
            }
        }
        return new(arr);
    }
}