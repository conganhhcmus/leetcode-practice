namespace Practice_2326;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int m = 3;
        int n = 5;
        int[] headArr = [3, 0, 2, 6, 8, 1, 7, 9, 4, 2, 5, 5, 0];

        var tmpNode = new ListNode();
        var head = tmpNode;
        foreach (var num in headArr)
        {
            tmpNode.next = new ListNode(num);
            tmpNode = tmpNode.next;
        }

        var res = solution.SpiralMatrix(m, n, head.next);
        Print2DArray(res);
    }
    private static void Print2DArray(int[][] array)
    {
        string[] rows = new string[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            rows[i] = $"[{string.Join(",", array[i])}]";
        }

        Console.WriteLine($"[{string.Join(",", rows)}]");
    }
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        int[][] res = new int[m][];
        for (int i = 0; i < m; i++)
        {
            res[i] = new int[n];
            Array.Fill(res[i], -1);
        }

        // Solution 1:
        // for (int level = 0; level < Math.Min(n, m) / 2 + 1; level++)
        // {
        //     // fill top
        //     for (int i = level; i < n - level; i++)
        //     {
        //         if (head is null) return res;
        //         res[level][i] = head.val;
        //         head = head.next;
        //     }

        //     // fill right
        //     for (int i = level + 1; i < m - level; i++)
        //     {
        //         if (head is null) return res;
        //         res[i][n - level - 1] = head.val;
        //         head = head.next;
        //     }

        //     // fill bottom
        //     for (int i = n - level - 2; i >= level; i--)
        //     {
        //         if (head is null) return res;
        //         res[m - level - 1][i] = head.val;
        //         head = head.next;
        //     }

        //     // fill left
        //     for (int i = m - level - 2; i > level; i--)
        //     {
        //         if (head is null) return res;
        //         res[i][level] = head.val;
        //         head = head.next;
        //     }
        // }

        // Solution 2:

        int topRow = 0;
        int bottomRow = m - 1;
        int leftCol = 0;
        int rightCol = n - 1;

        while (head is not null)
        {
            // fill top
            for (int i = leftCol; i <= rightCol && head is not null; i++)
            {
                res[topRow][i] = head.val;
                head = head.next;
            }
            topRow++;

            // fill right
            for (int i = topRow; i <= bottomRow && head is not null; i++)
            {
                res[i][rightCol] = head.val;
                head = head.next;
            }
            rightCol--;

            // fill bottom
            for (int i = rightCol; i >= leftCol && head is not null; i--)
            {
                res[bottomRow][i] = head.val;
                head = head.next;
            }
            bottomRow--;

            // fill left
            for (int i = bottomRow; i >= topRow && head is not null; i--)
            {
                res[i][leftCol] = head.val;
                head = head.next;
            }

            leftCol++;
        }
        return res;
    }
}