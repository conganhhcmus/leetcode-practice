namespace Library;

public class Sort
{
    // O (n^2)
    public void BubbleSort(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    // O (n^2)
    public void InsertionSort(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int key = nums[i];
            int j = i - 1;
            while (j >= 0 && nums[j] > key)
            {
                nums[j + 1] = nums[j];
                j--;
            }
            nums[j + 1] = key;
        }
    }

    // O (n^2)
    public void SelectionSort(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] < nums[minIndex])
                {
                    minIndex = j;
                }
            }
            (nums[i], nums[minIndex]) = (nums[minIndex], nums[i]);
        }
    }

    // O(m x n) m: key length, n is size of the array
    public void RadixSort(int[] nums)
    {
        int n = nums.Length;
        int[] temp = new int[n];

        // Flip the sign bit to handle negative numbers
        for (int i = 0; i < n; i++)
        {
            nums[i] ^= int.MinValue;
        }

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

        // Revert the sign bit flipping
        for (int i = 0; i < n; i++)
        {
            nums[i] ^= int.MinValue;
        }
    }
}