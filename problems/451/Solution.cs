public class Solution
{
    public string FrequencySort(string s)
    {
        int[] count = new int[128];
        int[] index = new int[128];
        for (int i = 0; i < 128; i++)
        {
            index[i] = i;
        }
        foreach (char c in s)
        {
            count[c]++;
        }
        Array.Sort(count, index);
        char[] arr = new char[s.Length];
        int curr = 0;
        for (int i = 127; i >= 0; i--)
        {
            for (int j = 0; j < count[i]; j++)
            {
                arr[curr + j] = (char)(index[i]);
            }
            curr += count[i];
        }
        return new(arr);
    }
}