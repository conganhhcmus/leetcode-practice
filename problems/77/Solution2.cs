#if DEBUG
namespace Problems_77_2;
#endif

public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> result = [];
        int[] current = new int[k];
        int position = 0;
        while (position >= 0)
        {
            current[position]++;
            if (n < current[position]) position--;
            else if (position == k - 1) result.Add([.. current]);
            else current[++position] = current[position - 1];
        }

        return result;
    }
}