public class Program
{
    private static readonly Dictionary<string, Func<string, object>> InputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, data => ListNodeHelper.CreateListFromArray(JsonConvert.DeserializeObject<int[]>(data)) },
        { typeof(TreeNode).FullName, data => TreeNodeHelper.CreateTreeFromArray(JsonConvert.DeserializeObject<int?[]>(data)) },
        { typeof(string).FullName, data => JsonConvert.DeserializeObject<string>(data) },
        { typeof(string[]).FullName, data => JsonConvert.DeserializeObject<string[]>(data) },
        { typeof(int).FullName, data => JsonConvert.DeserializeObject<int>(data) },
        { typeof(int[]).FullName, data => JsonConvert.DeserializeObject<int[]>(data) },
        { typeof(int[][]).FullName, data => JsonConvert.DeserializeObject<int[][]>(data) },
        { typeof(double).FullName, data => JsonConvert.DeserializeObject<double>(data) },
        { typeof(double[]).FullName, data => JsonConvert.DeserializeObject<double[]>(data) },
        { typeof(char).FullName, data => JsonConvert.DeserializeObject<char>(data) },
        { typeof(char[]).FullName, data => JsonConvert.DeserializeObject<char[]>(data) },
        { typeof(IList<int>).FullName, data => JsonConvert.DeserializeObject<IList<int>>(data) },
        { typeof(IList<IList<int>>).FullName, data => JsonConvert.DeserializeObject<IList<IList<int>>>(data) },
        { typeof(IList<IList<string>>).FullName, data => JsonConvert.DeserializeObject<IList<IList<string>>>(data) },
        { typeof(uint).FullName, data => Regex.IsMatch(data, "^[01]+$") ? Convert.ToUInt32(data, 2): JsonConvert.DeserializeObject<uint>(data) }
    };

    private static readonly Dictionary<string, Func<object, string>> OutputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, result => ListNodeHelper.PrintList((ListNode)result) },
        { typeof(TreeNode).FullName, result => TreeNodeHelper.BFSTraversal((TreeNode)result) }
    };

    private static void Main(string[] args)
    {
        MethodInfo methodInfo = typeof(Running.Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .FirstOrDefault();
        ArgumentNullException.ThrowIfNull(methodInfo, nameof(methodInfo));

        ParameterInfo[] parameters = methodInfo.GetParameters();
        ArgumentOutOfRangeException.ThrowIfZero(parameters.Length, nameof(parameters));

        object classInstance = Activator.CreateInstance(typeof(Running.Solution), null);
        ArgumentNullException.ThrowIfNull(classInstance, nameof(classInstance));

        List<string> testcases = GetTestcase();
        int loop = testcases.Count / parameters.Length, index = 0;
        List<string> output = [];
        List<long> executeTime = [];
        bool isReturnVoid = methodInfo.ReturnType.FullName == "System.Void";
        while (loop-- > 0)
        {
            object[] input = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++, index++)
            {
                Type type = parameters[i].ParameterType;
                var inputFunc = InputMapper.GetValueOrDefault(type.FullName, s => s);
                input[i] = inputFunc(testcases[index]);
            }
            var watch = Stopwatch.StartNew();
            var result = methodInfo.Invoke(classInstance, input);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var outputFunc = OutputMapper.GetValueOrDefault(methodInfo.ReturnType.FullName, JsonConvert.SerializeObject);

            output.Add(outputFunc(isReturnVoid ? input[0] : result));
            executeTime.Add(elapsedMs);
        }

        CheckAnswer(output, executeTime, isReturnVoid);
    }

    private static List<string> GetTestcase()
    {
        using StreamReader sr = new("testcase.txt");
        List<string> lines = [];
        var line = sr.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            lines.Add(line.Trim());
            line = sr.ReadLine();
        }

        return lines;
    }

    private static List<string> GetAnswer()
    {
        using StreamReader sr = new("answer.txt");
        List<string> lines = [];
        var line = sr.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            lines.Add(line.Trim());
            line = sr.ReadLine();
        }
        return lines;
    }

    private static void CheckAnswer(List<string> actual, List<long> executeTime, bool isReturnVoid)
    {
        Console.Clear();
        Console.WriteLine("Test Results:");
        List<string> expected = GetAnswer();

        if (isReturnVoid)
        {
            Console.WriteLine(string.Join("\n", actual));
            return;
        }

        if (expected.Count != actual.Count)
        {
            Console.WriteLine("Output is not correct!");
            return;
        }

        for (int i = 0; i < expected.Count; i++)
        {
            bool isCorrect = string.Compare(expected[i], actual[i]) == 0;
            bool isTLE = executeTime[i] > 2000;
            if (isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("✔ ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("✘ ");
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(expected);

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
    }
}