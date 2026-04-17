namespace Library;

public class BinarySearch
{
    // Finds the first index such that list[index] >= target
    public int LowerBound<T>(IReadOnlyList<T> list, T target)
        where T : IComparable<T>
    {
        int low = 0,
            high = list.Count - 1,
            ret = list.Count;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid].CompareTo(target) >= 0)
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

    // Finds the first index such that list[index] > target
    public int UpperBound<T>(IReadOnlyList<T> list, T target)
        where T : IComparable<T>
    {
        int low = 0,
            high = list.Count - 1,
            ret = list.Count;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid].CompareTo(target) > 0)
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

