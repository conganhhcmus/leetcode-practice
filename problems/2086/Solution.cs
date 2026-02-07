public class Solution
{
    public int MinimumBuckets(string hamsters)
    {
        // check exist 3 hamsters consequence
        if (!IsImpossible(hamsters)) return -1;

        // n = 10^5
        int n = hamsters.Length;
        List<int> hamsterList = [];
        for (int i = 0; i < n; i++)
        {
            if (hamsters[i] == 'H') hamsterList.Add(i);
        }
        char[] arr = hamsters.ToCharArray();
        foreach (int i in hamsterList)
        {
            if (i == 0) arr[i + 1] = 'x';
            else if (i == n - 1) arr[i - 1] = 'x';
            else if (arr[i - 1] == 'x' || arr[i + 1] == 'x') continue;
            else if (arr[i + 1] == '.') arr[i + 1] = 'x';
            else arr[i - 1] = 'x';
        }
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == 'x') ret++;
        }
        return ret;
    }

    bool IsImpossible(string hamsters)
    {
        int count = 1;
        foreach (char c in hamsters)
        {
            if (c == 'H') count++;
            else count = 0;
            if (count == 3) return false;
        }
        count++;
        if (count == 3) return false;
        return true;
    }
}