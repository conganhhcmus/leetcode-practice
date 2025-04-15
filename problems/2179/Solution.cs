#if DEBUG
namespace Problems_2179;
#endif

public class Solution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int[] map = new int[n];
        for (int i = 0; i < n; i++)
        {
            map[nums1[i]] = i;
        }
        long ret = 0;
        FenwickTree bit = new FenwickTree(n);
        for (int i = 0; i < n; i++)
        {
            int j = map[nums2[i]];
            int left = bit.Query(j);
            int right = (n - 1 - j) - (bit.Query(n - 1) - left);
            ret += 1L * left * right;
            bit.Update(j, 1);
        }
        return ret;
    }
}
public class FenwickTree
{
    readonly int[] bit;
    readonly int n;
    public FenwickTree(int n)
    {
        bit = new int[n + 1];
        this.n = n;
    }

    // O(log n)
    public void Update(int pos, int val) // update increment or decrement value
    {
        pos++;
        while (pos <= n)
        {
            bit[pos] += val; // sum
            // bit[pos] = Math.Max(bit[pos], val); // get max
            pos += (pos & -pos);
        }
    }

    // O(log n)
    public int Query(int pos) // query sum from 0 -> pos
    {
        int sum = 0;
        // int max = 0;
        pos++;
        while (pos > 0)
        {
            sum += bit[pos];
            // max = Math.Max(max, bit[pos]);
            pos -= (pos & -pos);
        }
        return sum;
        // return max;
    }
}