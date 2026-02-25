public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        Array.Sort(arr, (a, b) => Compare(a, b));
        return arr;
    }

    int Compare(int a, int b)
    {
        int cnta = PopCount(a);
        int cntb = PopCount(b);
        if (cnta == cntb) return a - b;
        return cnta - cntb;
    }

    int PopCount(int n)
    {
        int cnt = 0;
        while (n > 0)
        {
            cnt += n & 1;
            n >>= 1;
        }
        return cnt;
    }
}