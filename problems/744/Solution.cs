#if DEBUG
namespace Problems_744;
#endif

public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        int low = 0, high = letters.Length - 1, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (letters[mid] > target)
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return letters[ans];
    }
}