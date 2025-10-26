public class LeetCode
{
    public static List<string> GetTestcase()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "testcase.txt");
        using StreamReader sr = new(path);
        List<string> lines = [];
        var line = sr.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            lines.Add(line.Trim());
            line = sr.ReadLine();
        }

        return lines;
    }

    public static List<string> GetAnswer()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "answer.txt");
        using StreamReader sr = new(path);
        List<string> lines = [];
        var line = sr.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            lines.Add(line.Trim());
            line = sr.ReadLine();
        }
        return lines;
    }

    public static void CheckAnswer(List<string> expected, List<string> actual, List<long> executeTime)
    {
        // Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.OutputEncoding = Encoding.UTF8;

        if (expected.Count == 0)
        {
            Console.WriteLine("Output:");
            Console.WriteLine(string.Join("\n", actual));
            return;
        }

        if (expected.Count != actual.Count)
        {
            Console.WriteLine("Output is not correct!");
            return;
        }

        Console.WriteLine("Test Results:");
        for (int i = 0; i < expected.Count; i++)
        {
            bool isCorrect = string.Compare(expected[i], actual[i]) == 0;
            bool isTLE = executeTime[i] > 3000; // 3 seconds
            if (!isCorrect || isTLE)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("✘ ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("✔ ");
            }
            Console.WriteLine($"Testcase {i + 1} ({executeTime[i]} ms)");

            if (!isCorrect)
            {
                PrintDifferences(expected[i], actual[i]);
            }
            else if (isTLE)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Time Limit Exceeded");
            }
        }
    }

    private static void PrintDifferences(string expected, string actual)
    {
        int n = expected.Length, m = actual.Length;

        for (int i = 0; i < m; i++)
        {
            if (i > n - 1 || expected[i] != actual[i])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(actual[i]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(actual[i]);
            }
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(expected);
    }
}

#region Structures  ----------------------------------------------------------------
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

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

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

#endregion