
public class LeetCode
{
    public static List<string> GetTestcase()
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

    public static List<string> GetAnswer()
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

    public static void CheckAnswer(List<string> expected, List<string> actual, List<long> executeTime, bool isReturnVoid)
    {
        //Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;

        if (isReturnVoid || expected.Count == 0)
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
            bool isTLE = executeTime[i] > 2000; // 2 seconds
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