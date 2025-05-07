#if DEBUG
namespace Problems_912;
#endif

public class Solution
{
    public int[] SortArray(int[] nums)
    {
        HeapSort(nums);
        return nums;
    }

    void HeapSort(int[] nums)
    {
        for (int i = nums.Length / 2 - 1; i >= 0; i--)
        {
            Heapify(nums, nums.Length, i);
        }

        for (int i = nums.Length - 1; i > 0; i--)
        {
            (nums[i], nums[0]) = (nums[0], nums[i]);
            Heapify(nums, i, 0);
        }
    }

    void Heapify(int[] nums, int n, int i)
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int largest = i;
        if (left < n && nums[left] > nums[largest])
        {
            largest = left;
        }
        if (right < n && nums[right] > nums[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            (nums[largest], nums[i]) = (nums[i], nums[largest]);
            Heapify(nums, n, largest);
        }
    }
}