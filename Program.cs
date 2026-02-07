#if DEBUG
#pragma warning disable

using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;

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

public class Program
{
    #region Helper
    public static class ArrayHelper
    {
        public static string Print2DArray<T>(T[][] array)
        {
            string[] rows = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                rows[i] = $"[{string.Join(",", array[i])}]";
            }

            return JsonSerializer.Serialize(rows, JsonOptions);
        }

        public static string Print2DArray<T>(T[,] array)
        {
            string[] rows = new string[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                List<T> values = [];
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    values.Add(array[i, j]);
                }
                rows[i] = $"[{string.Join(",", values)}]";
            }

            return JsonSerializer.Serialize(rows, JsonOptions);
        }

        public static string Print2DArray<T>(IList<IList<T>> array)
        {
            string[] rows = new string[array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                rows[i] = $"[{string.Join(",", array[i])}]";
            }

            return JsonSerializer.Serialize(rows, JsonOptions);
        }
    }

    public static class ListNodeHelper
    {
        public static ListNode CreateListFromArray(int[] nums)
        {
            ListNode dummy = new();
            ListNode current = dummy;

            foreach (var num in nums)
            {
                current.next = new ListNode(num);
                current = current.next;
            }

            return dummy.next;
        }

        public static ListNode[] CreateListFrom2DArray(int[][] nums)
        {
            ListNode[] lists = new ListNode[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                lists[i] = CreateListFromArray(nums[i]);
            }

            return lists;
        }

        public static string PrintList(ListNode head)
        {
            List<int> vals = [];
            while (head is not null)
            {
                vals.Add(head.val);
                head = head.next;
            }

            return JsonSerializer.Serialize(vals, JsonOptions);
        }
    }

    public static class NodeHelper
    {
        public static Node CreateFromArray(int?[][] nums)
        {
            Node dummy = new(0);
            Node current = dummy;
            List<(Node node, int? random)> tmp = [];

            foreach (var num in nums)
            {
                int? val = num[0], random = num[1];
                tmp.Add((new Node(val.GetValueOrDefault()), random));
                current.next = tmp[^1].node;
                current = current.next;
            }

            foreach (var (node, random) in tmp)
            {
                if (random is null) continue;
                node.random = tmp.ElementAt(random.GetValueOrDefault()).node;
            }

            return dummy.next;
        }

        public static string Print(Node head)
        {
            List<Node> tmp = [];
            Node current = head;
            while (current is not null)
            {
                tmp.Add(current);
                current = current.next;
            }
            List<int?[]> vals = [];
            while (head is not null)
            {
                int index = tmp.IndexOf(head.random);
                vals.Add([head.val, index == -1 ? null : index]);
                head = head.next;
            }

            return JsonSerializer.Serialize(vals, JsonOptions);
        }
    }

    public static class TreeNodeHelper
    {
        public static TreeNode CreateTreeFromArray(int?[] array)
        {
            if (array.Length == 0) return null;
            int n = array.Length, h = 0;
            while ((1 << h) <= n) h++;
            var tmpTree = new TreeNode[(1 << h) - 1];
            for (int i = 0; i < n; i++)
            {
                if (array[i] is not null)
                {
                    tmpTree[i] = new TreeNode(array[i].Value);
                }
            }

            var last = 0;
            for (int i = 0; i < tmpTree.Length && last + 2 < tmpTree.Length; i++)
            {
                if (tmpTree[i] is not null)
                {
                    tmpTree[i].left = tmpTree[last + 1];
                    tmpTree[i].right = tmpTree[last + 2];
                    last += 2;
                }
            }

            return tmpTree[0];
        }

        public static string BFSTraversal(TreeNode root)
        {
            if (root is null) return "[]";
            List<int?> result = [];
            Queue<TreeNode> queue = [];
            queue.Enqueue(root);
            result.Add(root.val);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int?[] tmp = new int?[2 * size];
                bool hasValue = false;

                for (int i = 0; i < size; i++)
                {
                    var currentNode = queue.Dequeue();
                    if (currentNode.left is not null)
                    {
                        queue.Enqueue(currentNode.left);
                        tmp[2 * i] = currentNode.left.val;
                        hasValue = true;
                    }
                    if (currentNode.right is not null)
                    {
                        queue.Enqueue(currentNode.right);
                        tmp[2 * i + 1] = currentNode.right.val;
                        hasValue = true;
                    }
                }

                if (hasValue)
                {
                    result.AddRange(tmp);
                }
            }
            return JsonSerializer.Serialize(result, JsonOptions);
        }
    }

    #endregion

    private static readonly JsonSerializerOptions JsonOptions = new() { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };

    private static string Namespace => typeof(Solution).Namespace;

    private static readonly Dictionary<string, Func<string, object>> InputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, data => ListNodeHelper.CreateListFromArray(JsonSerializer.Deserialize<int[]>(data, JsonOptions)) },
        { typeof(ListNode[]).FullName, data => ListNodeHelper.CreateListFrom2DArray(JsonSerializer.Deserialize<int[][]>(data, JsonOptions)) },
        { typeof(TreeNode).FullName, data => TreeNodeHelper.CreateTreeFromArray(JsonSerializer.Deserialize<int?[]>(data, JsonOptions)) },
        { typeof(Node).FullName, data => NodeHelper.CreateFromArray(JsonSerializer.Deserialize<int?[][]>(data, JsonOptions)) },
        { typeof(uint).FullName, data => Regex.IsMatch(data, "^[01]+$") ? Convert.ToUInt32(data, 2) : JsonSerializer.Deserialize<uint>(data, JsonOptions) },
    };

    private static object DeserializeInput(Type type, string data)
    {
        if (InputMapper.TryGetValue(type.FullName, out var func))
            return func(data);

        return JsonSerializer.Deserialize(data, type, JsonOptions);
    }

    private static readonly Dictionary<string, Func<object, string>> OutputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, result => ListNodeHelper.PrintList((ListNode)result) },
        { typeof(TreeNode).FullName, result => TreeNodeHelper.BFSTraversal((TreeNode)result) },
        { typeof(Node).FullName, result => NodeHelper.Print((Node)result) },
        { typeof(IList<TreeNode>).FullName, result => $"[{string.Join(",", ((IList<TreeNode>)result).Select(TreeNodeHelper.BFSTraversal))}]" },
    };

    private static string SerializeOutput(string typeFullName, object result)
    {
        if (OutputMapper.TryGetValue(typeFullName, out var func))
            return func(result);

        return JsonSerializer.Serialize(result, JsonOptions);
    }

    private static void UpdateInputForSpeciallyProblems(object[] input, int inputIndex, List<string> testCases, ref int testCaseIndex)
    {
        switch (Namespace)
        {
            case string ns when ns.EndsWith("_141"):
                int pos = JsonSerializer.Deserialize<int>(testCases[++testCaseIndex], JsonOptions);
                if (pos < 0) break;
                ListNode head = input[inputIndex] as ListNode;
                ListNode tmp = head;
                while (pos-- >= 0) tmp = tmp.next;
                ListNode tail = tmp;
                while (tail.next != null) tail = tail.next;
                tail.next = tmp;
                input[inputIndex] = head;
                break;
        }
    }

    private static List<string> ReadLines(string path)
    {
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

    private static void CheckAnswer(List<string> expected, List<string> actual, List<long> executeTime)
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
        for (int i = 0; i < actual.Length; i++)
        {
            Console.ForegroundColor = (i >= expected.Length || expected[i] != actual[i]) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(actual[i]);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(expected);
    }

    private static string FindProjectRoot([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "")
    {
        var dir = Path.GetDirectoryName(sourceFilePath);
        while (dir != null)
        {
            if (Directory.Exists(Path.Combine(dir, ".git"))) return dir;
            dir = Path.GetDirectoryName(dir);
        }
        return Environment.CurrentDirectory;
    }

    private static void Main(string[] args)
    {
        MethodInfo methodInfo = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .FirstOrDefault();
        ArgumentNullException.ThrowIfNull(methodInfo, nameof(methodInfo));

        ParameterInfo[] parameters = methodInfo.GetParameters();
        ArgumentOutOfRangeException.ThrowIfZero(parameters.Length, nameof(parameters));

        var root = FindProjectRoot();
        List<string> testcases = ReadLines(Path.Combine(root, "input.txt"));
        int loop = testcases.Count / parameters.Length, index = 0;
        List<string> output = [];
        List<long> executeTime = [];
        bool isReturnVoid = methodInfo.ReturnType.FullName == "System.Void";
        string key = isReturnVoid ? parameters[0].ParameterType.FullName : methodInfo.ReturnType.FullName;
        while (loop-- > 0 && index < testcases.Count)
        {
            object[] input = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++, index++)
            {
                Type type = parameters[i].ParameterType;
                input[i] = DeserializeInput(type, testcases[index]);
                UpdateInputForSpeciallyProblems(input, i, testcases, ref index);
            }

            object classInstance = Activator.CreateInstance(typeof(Solution), null);
            ArgumentNullException.ThrowIfNull(classInstance, nameof(classInstance));

            var watch = Stopwatch.StartNew();
            var result = methodInfo.Invoke(classInstance, input);
            watch.Stop();
            executeTime.Add(watch.ElapsedMilliseconds);
            output.Add(SerializeOutput(key, isReturnVoid ? input[0] : result));
        }
        List<string> answer = ReadLines(Path.Combine(root, "output.txt"));
        CheckAnswer(answer, output, executeTime);
    }
}

#endif
