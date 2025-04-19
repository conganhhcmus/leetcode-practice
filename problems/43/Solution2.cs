#if DEBUG
namespace Problems_43_2;
#endif

public class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num1.Equals("0") || num2.Equals("0"))
        {
            return "0";
        }

        char[] firstNumber = num1.ToCharArray();
        char[] secondNumber = num2.ToCharArray();
        Array.Reverse(firstNumber);
        Array.Reverse(secondNumber);

        int firstNumLength = firstNumber.Length;
        int secondNumLength = secondNumber.Length;
        int resultArrayLength = firstNumLength + secondNumLength;
        int[] resultArray = new int[resultArrayLength];
        for (int place2 = 0; place2 < secondNumLength; place2++)
        {
            int digit2 = secondNumber[place2] - '0';
            for (int place1 = 0; place1 < firstNumLength; place1++)
            {
                int digit1 = firstNumber[place1] - '0';
                int numZeros = place1 + place2;
                int multiplication = digit1 * digit2 + resultArray[numZeros];
                resultArray[numZeros] = multiplication % 10;
                resultArray[numZeros + 1] += multiplication / 10;
            }
        }

        if (resultArray[^1] == 0)
        {
            resultArray = resultArray[..^1];
        }

        Array.Reverse(resultArray);
        return string.Join(string.Empty, resultArray);
    }
}