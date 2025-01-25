#if DEBUG
namespace Problems_1998;
#endif

public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] rank;

    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
    }

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return false;
        if (rank[rootX] < rank[rootY])
        {
            parent[rootX] = rootY;
            rank[rootY]++;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
        else
        {
            parent[rootX] = rootY;
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}

public class Solution
{
    public bool GcdSort(int[] nums)
    {
        int n = nums.Length;
        int[] cloned = [.. nums];
        RadixSort(cloned);
        if (IsEqual(nums, cloned)) return true;
        int maxValue = cloned[^1];
        int[] spf = BuildSpf(maxValue);
        UnionFind uf = new(maxValue + 1);
        foreach (int num in nums)
        {
            foreach (int prime in GetPrimeFactors(num, spf))
            {
                uf.Union(num, prime);
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == cloned[i]) continue;
            if (uf.Find(nums[i]) != uf.Find(cloned[i])) return false;
        }

        return true;
    }

    // Sieve Prime Factorization
    int[] BuildSpf(int maxValue)
    {
        int[] spf = new int[maxValue + 1];
        for (int i = 2; i <= maxValue; i++) spf[i] = i;
        for (int i = 2; i <= maxValue; i++)
        {
            if (spf[i] == i)
            {
                for (int j = 2 * i; j <= maxValue; j += i)
                {
                    if (spf[j] == j) spf[j] = i;
                }
            }
        }

        return spf;
    }

    List<int> GetPrimeFactors(int num, int[] spf)
    {
        List<int> factors = [];
        while (num > 1)
        {
            int prime = spf[num];
            factors.Add(prime);
            num /= prime;
        }

        return factors;
    }

    bool IsEqual(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length) return false;
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i]) return false;
        }
        return true;
    }

    public void RadixSort(int[] nums)
    {
        int n = nums.Length;
        int[] temp = new int[n];

        // Flip the sign bit to handle negative numbers
        for (int i = 0; i < n; i++)
        {
            nums[i] ^= int.MinValue;
        }

        const int BITS = 8;
        const int MASK = (1 << BITS) - 1;
        int[] counts = new int[1 << BITS];

        // Perform counting sort for each byte (total of 4 passes for 32-bit integers)
        for (int shift = 0; shift < 32; shift += BITS)
        {
            Array.Clear(counts, 0, counts.Length);

            // Counting occurrences
            for (int i = 0; i < n; i++)
            {
                int c = (nums[i] >> shift) & MASK;
                counts[c]++;
            }

            // Compute prefix sums
            int sum = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int tempCount = counts[i];
                counts[i] = sum;
                sum += tempCount;
            }

            // Sort based on the current byte
            for (int i = 0; i < n; i++)
            {
                int c = (nums[i] >> shift) & MASK;
                temp[counts[c]++] = nums[i];
            }

            // Copy back to the original array
            Array.Copy(temp, nums, n);
        }

        // Revert the sign bit flipping
        for (int i = 0; i < n; i++)
        {
            nums[i] ^= int.MinValue;
        }
    }
}