#if DEBUG
namespace Problems_1524_2;
#endif

public class Solution
{
    public int NumOfSubarrays(int[] arr)
    {
        int odd = 0, sum = 0;

        foreach (var num in arr)
        {
            sum += num;
            odd += sum % 2;
        }

        int even = arr.Length - odd;
        // The number of subarrays with odd sums is the product of the count of even and odd prefix sums, 
        // because combining an even prefix sum with an odd one results in an odd sum.
        // Additionally, any subarray whose prefix sum is odd is itself an odd subarray.
        return (int)((1L * even * odd + odd) % 1_000_000_007);
    }
}