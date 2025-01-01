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

        List<string> data = Input();
        int loop = data.Count / parameters.Length;
        int index = 0;
        List<(string output, long executeTime)> lines = [];
        while (loop-- > 0)
        {
            object[] input = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++, index++)
            {
                Type type = parameters[i].ParameterType;
                var inputFunc = InputMapper.GetValueOrDefault(type.FullName, s => s);
                input[i] = inputFunc(data[index]);
            }
            var watch = Stopwatch.StartNew();
            var result = methodInfo.Invoke(classInstance, input);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var outputFunc = OutputMapper.GetValueOrDefault(methodInfo.ReturnType.FullName, JsonConvert.SerializeObject);
            lines.Add((outputFunc(result), elapsedMs));
        }

        Compare(lines);
    }

    private static List<string> Input()
    {
        using StreamReader sr = new("input.txt");
        List<string> lines = [];
        var line = sr.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            lines.Add(line.Trim());
            line = sr.ReadLine();
        }

        return lines;
    }

    private static void Output(List<string> lines)
    {
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }

    private static void Compare(List<(string output, long executeTime)> output)
    {
        Console.Clear();
        Console.ResetColor();

        using StreamReader sr = new("output.txt");
        List<string> expected = [];
        var line = sr.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            expected.Add(line.Trim());
            line = sr.ReadLine();
        }
        List<(string output, long executeTime)> actual = output.Where(x => !string.IsNullOrEmpty(x.output)).ToList();

        if (expected.Count == 0)
        {
            Output(actual.Select(x => x.output).ToList());
            return;
        }

        if (expected.Count != actual.Count)
        {
            Console.WriteLine("Output is not correct");
            return;
        }

        for (int i = 0; i < expected.Count; i++)
        {
            bool isCorrect = string.Compare(expected[i], actual[i].output) == 0;
            bool isTLE = actual[i].executeTime > 2000;
            Console.ResetColor();
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
            Console.WriteLine($"Testcase {i + 1} ({actual[i].executeTime} ms)");
            if (!isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(actual[i].output);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(expected[i]);
            }
            else if (isTLE)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Time Limit Exceeded");
            }
        }
    }
}