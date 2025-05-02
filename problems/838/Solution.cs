#if DEBUG
namespace Problems_838;
#endif

public class Solution
{
    public string PushDominoes(string dominoes)
    {
        // n = 10^5
        int n = dominoes.Length;
        char[] ret = dominoes.ToCharArray();
        (char, int)[] prefixState = new (char, int)[n];
        prefixState[0] = ('.', -1);
        for (int i = 1; i < n; i++)
        {
            if (ret[i - 1] != '.')
            {
                prefixState[i] = (ret[i - 1], i - 1);
            }
            else
            {
                prefixState[i] = prefixState[i - 1];
            }
        }
        (char, int)[] suffixState = new (char, int)[n];
        suffixState[n - 1] = ('.', n);
        for (int i = n - 2; i >= 0; i--)
        {
            if (ret[i + 1] != '.')
            {
                suffixState[i] = (ret[i + 1], i + 1);
            }
            else
            {
                suffixState[i] = suffixState[i + 1];
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (ret[i] != '.') continue;
            var left = prefixState[i];
            var right = suffixState[i];
            int diff1 = Math.Abs(left.Item2 - i);
            int diff2 = Math.Abs(right.Item2 - i);
            if ((left.Item1 == 'L' || left.Item1 == '.') && (right.Item1 == 'R' || right.Item1 == '.'))
            {
                // do nothing
            }
            else if (left.Item1 == 'R' && right.Item1 == 'L')
            {
                if (diff1 == diff2)
                {
                    // do nothing
                }
                else if (diff1 > diff2) ret[i] = 'L';
                else ret[i] = 'R';
            }
            else if (left.Item1 == 'R') ret[i] = 'R';
            else ret[i] = 'L';
        }
        return new(ret);
    }
}