public class Solution
{
    long INF = (long)1e15;

    public long MaxSumTrionic(int[] nums)
    {
        long ans = -INF;
        int n = nums.Length;
        int state = 0; // 0: init state, 1: increase, 2: decrease, 3: increase again
        long sum1 = 0, sum2 = 0;
        long initSum = 0;
        for (int i = 1; i < n; i++)
        {
            int first = nums[i - 1], second = nums[i];
            if (second - first > 0)
            {
                if (state == 0)
                {
                    state = 1;
                    initSum = first;
                    sum1 = first + second;
                }
                else if (state == 1)
                {
                    if (initSum < 0)
                    {
                        sum1 -= initSum;
                        initSum = first;
                    }
                    sum1 += second;
                }
                else if (state == 2)
                {
                    state = 3;
                    initSum = first;
                    sum2 = sum1 + second;
                    sum1 = first + second;
                    if (sum2 > ans)
                    {
                        ans = sum2;
                    }
                }
                else
                {
                    if (initSum < 0)
                    {
                        sum1 -= initSum;
                        initSum = first;
                    }
                    sum1 += second;
                    sum2 += second;
                    if (sum2 > ans)
                    {
                        ans = sum2;
                    }
                }
            }
            else if (second - first < 0)
            {
                if (state > 0)
                {
                    state = 2;
                    sum1 += second;
                }
            }
            else
            {
                state = 0;
            }
        }

        return ans;
    }
}