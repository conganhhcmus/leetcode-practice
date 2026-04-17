namespace Library;

public class FenwickTree
{
    readonly long[] bit;
    readonly int n;

    public FenwickTree(long[] nums)
    {
        n = nums.Length;
        bit = new long[n + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            Update(i, nums[i]);
        }
    }

    public FenwickTree(int[] nums)
        : this(Array.ConvertAll(nums, x => (long)x)) { }

    // O(log n)
    void Update(int pos, long val) // update increment or decrement value
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
    long Query(long pos) // query sum from 0 -> pos
    {
        long sum = 0;
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

