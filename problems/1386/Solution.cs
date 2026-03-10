public class Solution
{
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
    {
        int ans = 0;
        Dictionary<int, int> dict = [];
        foreach (int[] seat in reservedSeats)
        {
            int r = seat[0], c = seat[1];
            int bit = 1 << (c - 1);
            dict[r] = dict.GetValueOrDefault(r) | bit;
        }

        // row without reserved seats can fit 2 4-person families
        ans += 2 * (n - dict.Count);
        // check each row that has reserved seats

        int right = 0b0111100000;
        int middle = 0b0001111000;
        int left = 0b0000011110;
        foreach (var kv in dict)
        {
            int count = 0;
            if ((kv.Value & right) == 0) count++;
            if ((kv.Value & left) == 0) count++;
            if (count == 0 && (kv.Value & middle) == 0) count++;
            ans += count;
        }
        return ans;
    }
}