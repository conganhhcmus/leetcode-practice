namespace Problem_2336;

public class SmallestInfiniteSet
{
    private int current;
    private int heapSize;
    private readonly int[] heap;
    private bool[] isContained;

    public SmallestInfiniteSet()
    {
        current = 1;
        heapSize = 0;
        heap = new int[1000];
        isContained = new bool[1001];
    }

    public int PopSmallest()
    {
        if (heapSize == 0)
        {
            return current++;
        }

        var result = heap[0];
        heap[0] = heap[--heapSize];
        heap[heapSize] = 0;
        HeapifyDown(0, heap[0]);

        isContained[result] = false;
        return result;
    }

    public void AddBack(int num)
    {
        if (num >= current || isContained[num]) return;

        isContained[num] = true;
        heap[heapSize] = num;
        HeapifyUp(heapSize, num);
        heapSize++;
    }

    private void HeapifyUp(int index, int value)
    {
        if (index < 1) return;

        var parent = (index - (index % 2 == 0 ? 2 : 1)) / 2;
        var parentValue = heap[parent];

        if (value >= parentValue)
        {
            return;
        }

        heap[index] = parentValue;
        heap[parent] = value;
        HeapifyUp(parent, value);
    }

    private void HeapifyDown(int index, int value)
    {
        if (index >= heapSize) return;

        var child1 = index * 2 + 1;
        var child2 = index * 2 + 2;

        var child1Value = child1 < heapSize ? heap[child1] : int.MaxValue;
        var child2Value = child2 < heapSize ? heap[child2] : int.MaxValue;

        var (swapIndex, swapValue) = child1Value < child2Value ? (child1, child1Value) : (child2, child2Value);
        if (swapValue > value)
        {
            return;
        }

        heap[swapIndex] = value;
        heap[index] = swapValue;
        HeapifyDown(swapIndex, value);
    }
}

public class Solution
{
    public static void Execute()
    {
        // key: use HeapSort to sort the values

        string[] actions = ["SmallestInfiniteSet", "addBack", "popSmallest", "popSmallest", "popSmallest", "addBack", "popSmallest", "popSmallest", "popSmallest"];
        int[][] values = [[], [2], [], [], [], [1], [], [], []];
        List<int?> result = [];
        SmallestInfiniteSet s = new();
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "SmallestInfiniteSet":
                    s = new SmallestInfiniteSet();
                    break;
                case "addBack":
                    s.AddBack(values[i][0]);
                    result.Add(null);
                    break;
                case "popSmallest":
                    result.Add(s.PopSmallest());
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine($"[{string.Join(",", result.Select(x => x is null ? "null" : x.ToString()))}]");
    }
}