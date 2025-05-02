#if DEBUG
namespace Problems_838_2;
#endif

public class Solution
{
    public string PushDominoes(string dominoes)
    {
        // 'L'+dominoes+'R
        int n = dominoes.Length;
        Pair[] map = new Pair[n + 2];
        int len = 1;
        map[0] = new(-1, 'L');
        for (int i = 0; i < n; i++)
        {
            if (dominoes[i] != '.')
            {
                map[len++] = new(i, dominoes[i]);
            }
        }
        map[len++] = new(n, 'R');
        char[] ret = dominoes.ToCharArray();
        for (int index = 0; index < len - 1; index++)
        {
            Pair left = map[index];
            Pair right = map[index + 1];
            if (left.Symbol == right.Symbol)
            {
                for (int i = left.Index + 1; i < right.Index; i++)
                {
                    ret[i] = left.Symbol;
                }
            }
            else if (left.Symbol > right.Symbol)
            { // 'R' > 'L
                int i = left.Index + 1, j = right.Index - 1;
                while (i < j)
                {
                    ret[i] = left.Symbol;
                    ret[j] = right.Symbol;
                    i++;
                    j--;
                }
            }
        }
        return new(ret);
    }

    public record Pair(int Index, char Symbol);
}