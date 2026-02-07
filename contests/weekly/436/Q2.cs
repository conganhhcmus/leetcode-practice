public class Solution
{
    public int[] AssignElements(int[] groups, int[] elements)
    {
        int n = groups.Length, m = elements.Length;
        int[] ans = new int[n];
        Dictionary<int, int> elementToIndex = [];
        for (int i = 0; i < m; i++)
        {
            if (!elementToIndex.ContainsKey(elements[i])) elementToIndex[elements[i]] = i;
        }

        for (int i = 0; i < n; i++)
        {
            int minIndex = int.MaxValue;
            List<int> divisors = GetDivisors(groups[i]);
            foreach (int d in divisors)
            {
                if (elementToIndex.TryGetValue(d, out int index))
                {
                    if (index == 0)
                    {
                        minIndex = 0;
                        break;
                    }

                    if (index < minIndex)
                    {
                        minIndex = index;
                    }
                }
            }
            ans[i] = minIndex == int.MaxValue ? -1 : minIndex;
        }

        return ans;
    }

    private List<int> GetDivisors(int n)
    {
        List<int> divisors = new List<int>();
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
                int other = n / i;
                if (other != i)
                {
                    divisors.Add(other);
                }
            }
        }
        return divisors;
    }
}