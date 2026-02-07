public class Solution
{
    public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
    {
        int n = nums.Length;
        int len = nums[0].Length;
        int[][] memo = new int[len + 1][];
        for (int i = 0; i <= len; i++)
        {
            memo[i] = new int[n];
        }
        for (int i = 0; i < n; i++)
        {
            memo[0][i] = i;
        }

        RadixSort(nums, memo);
        int m = queries.Length;
        int[] ret = new int[m];
        for (int i = 0; i < m; i++)
        {
            int idx = queries[i][0], place = queries[i][1];
            ret[i] = memo[place][idx - 1];
        }

        return ret;
    }

    void RadixSort(string[] nums, int[][] memo)
    {
        int n = nums.Length;
        int len = nums[0].Length;

        int[] counts = new int[10];
        for (int place = 1; place <= len; place++)
        {
            Array.Clear(counts);
            for (int i = 0; i < n; i++)
            {
                int key = nums[i][^place] - '0';
                counts[key]++;
            }

            int startIdx = 0;
            for (int i = 0; i < 10; i++)
            {
                int count = counts[i];
                counts[i] = startIdx;
                startIdx += count;
            }

            int[] sortedIndex = new int[n];
            string[] sortedArray = new string[n];
            for (int i = 0; i < n; i++)
            {
                int key = nums[i][^place] - '0';
                sortedIndex[counts[key]] = memo[place - 1][i];
                sortedArray[counts[key]] = nums[i];
                counts[key]++;
            }

            Array.Copy(sortedIndex, memo[place], n);
            Array.Copy(sortedArray, nums, n);
        }
    }
}