public class Program
{
    private static string Namespace => typeof(Running.Solution).Namespace;

    private static readonly Dictionary<string, Func<string, object>> InputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, data => ListNodeHelper.CreateListFromArray(JsonConvert.DeserializeObject<int[]>(data)) },
        { typeof(ListNode[]).FullName, data => ListNodeHelper.CreateListFrom2DArray(JsonConvert.DeserializeObject<int[][]>(data)) },
        { typeof(TreeNode).FullName, data => TreeNodeHelper.CreateTreeFromArray(JsonConvert.DeserializeObject<int?[]>(data)) },
        { typeof(Node).FullName, data => NodeHelper.CreateFromArray(JsonConvert.DeserializeObject<int?[][]>(data)) },
        { typeof(string).FullName, data => JsonConvert.DeserializeObject<string>(data) },
        { typeof(string[]).FullName, data => JsonConvert.DeserializeObject<string[]>(data) },
        { typeof(string[][]).FullName, data => JsonConvert.DeserializeObject<string[][]>(data) },
        { typeof(int).FullName, data => JsonConvert.DeserializeObject<int>(data) },
        { typeof(int[]).FullName, data => JsonConvert.DeserializeObject<int[]>(data) },
        { typeof(int[][]).FullName, data => JsonConvert.DeserializeObject<int[][]>(data) },
        { typeof(int[][][]).FullName, data => JsonConvert.DeserializeObject<int[][][]>(data) },
        { typeof(int?[]).FullName, data => JsonConvert.DeserializeObject<int?[]>(data) },
        { typeof(int?[][]).FullName, data => JsonConvert.DeserializeObject<int?[][]>(data) },
        { typeof(int?[][][]).FullName, data => JsonConvert.DeserializeObject<int?[][][]>(data) },
        { typeof(long).FullName, data => JsonConvert.DeserializeObject<long>(data) },
        { typeof(long[]).FullName, data => JsonConvert.DeserializeObject<long[]>(data) },
        { typeof(long[][]).FullName, data => JsonConvert.DeserializeObject<long[][]>(data) },
        { typeof(double).FullName, data => JsonConvert.DeserializeObject<double>(data) },
        { typeof(double[]).FullName, data => JsonConvert.DeserializeObject<double[]>(data) },
        { typeof(double[][]).FullName, data => JsonConvert.DeserializeObject<double[][]>(data) },
        { typeof(char).FullName, data => JsonConvert.DeserializeObject<char>(data) },
        { typeof(char[]).FullName, data => JsonConvert.DeserializeObject<char[]>(data) },
        { typeof(char[][]).FullName, data => JsonConvert.DeserializeObject<char[][]>(data) },
        { typeof(IList<int>).FullName, data => JsonConvert.DeserializeObject<IList<int>>(data) },
        { typeof(IList<IList<int>>).FullName, data => JsonConvert.DeserializeObject<IList<IList<int>>>(data) },
        { typeof(IList<IList<string>>).FullName, data => JsonConvert.DeserializeObject<IList<IList<string>>>(data) },
        { typeof(uint).FullName, data => Regex.IsMatch(data, "^[01]+$") ? Convert.ToUInt32(data, 2): JsonConvert.DeserializeObject<uint>(data) }
    };

    private static readonly Dictionary<string, Func<object, string>> OutputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, result => ListNodeHelper.PrintList((ListNode)result) },
        { typeof(TreeNode).FullName, result => TreeNodeHelper.BFSTraversal((TreeNode)result)},
        { typeof(Node).FullName, result => NodeHelper.Print((Node)result) }
    };

    private static void UpdateInputForSpeciallyProblems(object[] input, int inputIndex, List<string> testCases, ref int testCaseIndex)
    {
        switch (Namespace)
        {
            case string ns when ns.Contains("141"):
                int pos = JsonConvert.DeserializeObject<int>(testCases[++testCaseIndex]);
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

        List<string> testcases = LeetCode.GetTestcase();
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
                var inputFunc = InputMapper.GetValueOrDefault(type.FullName, s => s);
                input[i] = inputFunc(testcases[index]);
                UpdateInputForSpeciallyProblems(input, i, testcases, ref index);
            }
            var watch = Stopwatch.StartNew();
            var result = methodInfo.Invoke(classInstance, input);
            watch.Stop();
            executeTime.Add(watch.ElapsedMilliseconds);
            var outputFunc = OutputMapper.GetValueOrDefault(key, JsonConvert.SerializeObject);
            output.Add(outputFunc(isReturnVoid ? input[0] : result));
        }
        List<string> answer = LeetCode.GetAnswer();
        LeetCode.CheckAnswer(answer, output, executeTime);
    }
}