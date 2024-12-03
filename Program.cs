using Running = Problems_274;

public class Program
{
    private static readonly Dictionary<string, Func<string, object>> Mapper = new(StringComparer.OrdinalIgnoreCase){
        { typeof(ListNode).FullName, (data) => ListNodeHelper.CreateListFromArray(JsonConvert.DeserializeObject<int[]>(data))},
        { typeof(TreeNode).FullName, (data) => TreeNodeHelper.CreateTreeFromArray(JsonConvert.DeserializeObject<int?[]>(data))},
        { typeof(string).FullName, (data) => JsonConvert.DeserializeObject<string>(data)},
        { typeof(string[]).FullName, (data) => JsonConvert.DeserializeObject<string[]>(data)},
        { typeof(int).FullName, (data) => JsonConvert.DeserializeObject<int>(data)},
        { typeof(int[]).FullName, (data) => JsonConvert.DeserializeObject<int[]>(data)},
        { typeof(int[][]).FullName, (data) => JsonConvert.DeserializeObject<int[][]>(data)},
        { typeof(char).FullName, (data) => JsonConvert.DeserializeObject<char>(data)},
        { typeof(char[]).FullName, (data) => JsonConvert.DeserializeObject<char[]>(data)},
        { typeof(IList<int>).FullName, (data) => JsonConvert.DeserializeObject<IList<int>>(data)},
        { typeof(IList<IList<int>>).FullName, (data) => JsonConvert.DeserializeObject<IList<IList<int>>>(data)},
    };

    private static void Main(string[] args)
    {
        var data = Input();
        MethodInfo methodInfo = typeof(Running.Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .FirstOrDefault();

        if (methodInfo is null) throw new ArgumentNullException(nameof(methodInfo));
        var parameters = methodInfo.GetParameters();
        if (parameters.Length == 0) throw new ArgumentOutOfRangeException();

        object classInstance = Activator.CreateInstance(typeof(Running.Solution), null);
        int loop = data.Count / parameters.Length;
        int index = 0;
        List<string> lines = [];
        while (loop-- > 0)
        {
            object[] input = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++, index++)
            {
                Type type = parameters[i].ParameterType;
                var func = Mapper.GetValueOrDefault(type.FullName, (data) => data);
                input[i] = func(data[index]);
            }
            var result = methodInfo.Invoke(classInstance, input);
            lines.Add(methodInfo.ReturnType.Name switch
            {
                "ListNode" => ListNodeHelper.PrintList((ListNode)result),
                "TreeNode" => TreeNodeHelper.BFSTraversal((TreeNode)result),
                _ => JsonConvert.SerializeObject(result)
            });
        }

        Output(lines);
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
        using StreamWriter sw = new("output.txt");
        foreach (var line in lines)
        {
            sw.WriteLine(line);
        }
    }
}