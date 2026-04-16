public class Solution
{
    static bool initialized = false;
    static int MAX = 100_050;
    static bool[] IsPrime = new bool[MAX];

    void Init()
    {
        if (initialized)
            return;
        initialized = true;
        Array.Fill(IsPrime, true);
        IsPrime[0] = IsPrime[1] = false;
        for (int i = 2; i * i < MAX; i++)
        {
            if (IsPrime[i])
            {
                for (int j = i * i; j < MAX; j += i)
                {
                    IsPrime[j] = false;
                }
            }
        }
    }

    public int MinOperations(int[] nums)
    {
        Init();
        int[] nextPrime = new int[MAX];
        int lastPrime = 2;
        for (int i = MAX - 1; i >= 0; i--)
        {
            if (IsPrime[i])
                lastPrime = i;
            nextPrime[i] = lastPrime;
        }
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                if (IsPrime[nums[i]])
                    continue;
                ans += nextPrime[nums[i]] - nums[i];
            }
            else
            {
                if (!IsPrime[nums[i]])
                    continue;
                ans += (nums[i] % 2 == 0) ? 2 : 1;
            }
        }
        return ans;
    }
}
