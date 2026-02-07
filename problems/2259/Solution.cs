public class Solution
{
    public string RemoveDigit(string number, char digit)
    {
        StringBuilder sb = new();
        int n = number.Length;
        List<int> idx = [];
        for (int i = 0; i < n; i++)
        {
            if (number[i] == digit) idx.Add(i);
        }

        int removeAt = idx[^1];
        for (int i = 0; i < idx.Count - 1; i++)
        {
            if (number[idx[i]] < number[idx[i] + 1])
            {
                removeAt = idx[i];
                break;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (i == removeAt) continue;
            sb.Append(number[i]);
        }

        return sb.ToString();
    }
}