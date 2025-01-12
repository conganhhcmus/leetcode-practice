public class Program
{
    private static readonly Dictionary<string, Func<string, object>> InputMapper = new(StringComparer.OrdinalIgnoreCase)
    {
        { typeof(ListNode).FullName, data => ListNodeHelper.CreateListFromArray(JsonConvert.DeserializeObject<int[]>(data)) },
        { typeof(TreeNode).FullName, data => TreeNodeHelper.CreateTreeFromArray(JsonConvert.DeserializeObject<int?[]>(data)) },
        { typeof(string).FullName, data => JsonConvert.DeserializeObject<string>(data) },
        { typeof(string[]).FullName, data => JsonConvert.DeserializeObject<string[]>(data) },
        { typeof(string[][]).FullName, data => JsonConvert.DeserializeObject<string[][]>(data) },
        { typeof(int).FullName, data => JsonConvert.DeserializeObject<int>(data) },
        { typeof(int[]).FullName, data => JsonConvert.DeserializeObject<int[]>(data) },
        { typeof(int[][]).FullName, data => JsonConvert.DeserializeObject<int[][]>(data) },
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

        List<string> testcases = LeetCode.GetTestcase();
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
            executeTime.Add(watch.ElapsedMilliseconds);
            var outputFunc = OutputMapper.GetValueOrDefault(methodInfo.ReturnType.FullName, JsonConvert.SerializeObject);
            output.Add(outputFunc(isReturnVoid ? input[0] : result));
        }
        List<string> answer = LeetCode.GetAnswer();
        LeetCode.CheckAnswer(answer, output, executeTime, isReturnVoid);
    }
}