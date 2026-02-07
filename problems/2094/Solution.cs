public class Solution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        int[] count = new int[10];
        int n = digits.Length;
        foreach (int d in digits)
        {
            count[d]++;
        }
        Backtracking(0, 3, count, 0);
        // ret.Sort();
        return [.. ret];
    }

    List<int> ret = [];

    void Backtracking(int pos, int n, int[] count, int curr)
    {
        if (pos >= n)
        {
            if (curr % 2 == 0) ret.Add(curr);
            return;
        }
        for (int i = 0; i < 10; i++)
        {
            if (pos == 0 && i == 0) continue;
            if (count[i] > 0)
            {
                count[i]--;
                Backtracking(pos + 1, n, count, curr * 10 + i);
                count[i]++;
            }
        }
    }
}