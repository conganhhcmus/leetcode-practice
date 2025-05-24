#if DEBUG
namespace Problems_2565;
#endif

public class Solution
{
    public int MinimumScore(string s, string t)
    {
        int n = t.Length;
        int[] leftmost = BuildLeft(s, t);
        int[] rightmost = BuildRight(s, t);

        int ret = n;

        for (int i = 0; i <= n; i++)
        {
            int low = i, high = n;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (leftmost[i] < rightmost[mid])
                {
                    ret = Math.Min(ret, mid - i);
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
        }

        return ret;
    }
    int[] BuildLeft(string s, string t)
    {
        int[] leftmost = new int[t.Length + 1];
        leftmost[0] = -1;
        int j = 0;

        for (int i = 0; i < t.Length; i++)
        {
            while (j < s.Length && s[j] != t[i]) j++;
            leftmost[i + 1] = j;
            j++;
        }

        return leftmost;
    }

    int[] BuildRight(string s, string t)
    {
        int[] rightmost = new int[t.Length + 1];
        rightmost[^1] = s.Length;
        int j = s.Length - 1;

        for (int i = t.Length - 1; i >= 0; i--)
        {
            while (j >= 0 && s[j] != t[i]) j--;
            rightmost[i] = j;
            j--;
        }

        return rightmost;
    }
}