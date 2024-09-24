namespace Problem_241;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string expression = "2*3-4*5";
        Console.WriteLine($"[{string.Join(",", solution.DiffWaysToCompute(expression))}]");
    }
    public IList<int> DiffWaysToCompute(string expression)
    {
        var dp = new List<int>[expression.Length, expression.Length];
        for (int i = 0; i < expression.Length; i++)
        {
            for (int j = 0; j < expression.Length; j++)
            {
                dp[i, j] = [];
            }
        }
        for (int i = 0; i < expression.Length; i++)
        {
            if (char.IsDigit(expression[i]))
            {
                if (i + 1 < expression.Length && char.IsDigit(expression[i + 1]))
                {
                    dp[i, i + 1].Add(int.Parse(expression[i..(i + 2)]));
                }
                else
                {
                    dp[i, i].Add(int.Parse(expression[i..(i + 1)]));
                }
            }
        }

        for (int len = 3; len <= expression.Length; len++)
        {
            for (int start = 0; start + len - 1 < expression.Length; start++)
            {
                int end = start + len - 1;
                for (int split = start; split < end; split++)
                {
                    if (char.IsDigit(expression[split])) continue;

                    var left = dp[start, split - 1];
                    var right = dp[split + 1, end];

                    foreach (var leftValue in left)
                    {
                        foreach (var rightValue in right)
                        {
                            switch (expression[split])
                            {
                                case '-':
                                    dp[start, end].Add(leftValue - rightValue);
                                    break;
                                case '+':
                                    dp[start, end].Add(leftValue + rightValue);
                                    break;
                                case '*':
                                    dp[start, end].Add(leftValue * rightValue);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        return dp[0, expression.Length - 1];
    }
}