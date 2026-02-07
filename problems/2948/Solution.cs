public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        int n = nums.Length;
        int[] cloned = [.. nums];
        RadixSort(cloned);
        // Array.Sort(cloned);
        List<Queue<int>> groups = [];
        int level = 0;
        groups.Add([]);
        groups[level].Enqueue(cloned[0]);
        Dictionary<int, int> map = [];
        map[cloned[0]] = level;
        for (int i = 1; i < n; i++)
        {
            if (cloned[i] - cloned[i - 1] <= limit)
            {
                groups[level].Enqueue(cloned[i]);
                map[cloned[i]] = level;
            }
            else
            {
                level++;
                groups.Add([]);
                groups[level].Enqueue(cloned[i]);
                map[cloned[i]] = level;
            }
        }

        for (int i = 0; i < n; i++)
        {
            level = map[nums[i]];
            nums[i] = groups[level].Dequeue();
        }

        return nums;
    }

    private void RadixSort(int[] nums)
    {
        int n = nums.Length;
        int[] temp = new int[n];

        // // Flip the sign bit to handle negative numbers
        // for (int i = 0; i < n; i++)
        // {
        //     nums[i] ^= int.MinValue;
        // }

        const int BITS = 8;
        const int MASK = (1 << BITS) - 1;
        int[] counts = new int[1 << BITS];

        // Perform counting sort for each byte (total of 4 passes for 32-bit integers)
        for (int shift = 0; shift < 32; shift += BITS)
        {
            Array.Clear(counts, 0, counts.Length);

            // Counting occurrences
            for (int i = 0; i < n; i++)
            {
                int c = (nums[i] >> shift) & MASK;
                counts[c]++;
            }

            // Compute prefix sums
            int sum = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int tempCount = counts[i];
                counts[i] = sum;
                sum += tempCount;
            }

            // Sort based on the current byte
            for (int i = 0; i < n; i++)
            {
                int c = (nums[i] >> shift) & MASK;
                temp[counts[c]++] = nums[i];
            }

            // Copy back to the original array
            Array.Copy(temp, nums, n);
        }

        // // Revert the sign bit flipping
        // for (int i = 0; i < n; i++)
        // {
        //     nums[i] ^= int.MinValue;
        // }
    }
}

