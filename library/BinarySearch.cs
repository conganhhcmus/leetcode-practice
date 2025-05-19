namespace Library;

public class BinarySearch
{
    // Finds the first index in the list such that list[index] >= target
    int LowerBound(List<int> list, int target)
    {
        int low = 0, high = list.Count - 1, ret = list.Count;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid] >= target)
            {
                ret = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ret;
    }

    // Finds the first index in the list such that list[index] > target
    int UpperBound(List<int> list, int target)
    {
        int low = 0, high = list.Count - 1, ret = list.Count;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid] > target)
            {
                ret = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ret;
    }
}