public class Solution
{
    public bool ReorderedPowerOf2(int n)
    {
        List<int> powerOfTwoNumber = [];
        for (int i = 0; i < 32; i++)
        {
            powerOfTwoNumber.Add(1 << i);
        }
        List<int> digits = Digits(n);
        digits.Sort();

        List<List<int>> candidates = [];
        foreach (int num in powerOfTwoNumber)
        {
            List<int> digit = Digits(num);
            digit.Sort();
            candidates.Add(digit);
        }

        foreach (List<int> candidate in candidates)
        {
            if (candidate.Count == digits.Count)
            {
                bool isValid = true;
                for (int i = 0; i < digits.Count; i++)
                {
                    if (candidate[i] != digits[i])
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid) return true;
            }
        }

        return false;
    }

    List<int> Digits(int num)
    {
        List<int> ans = [];
        while (num > 0)
        {
            ans.Add(num % 10);
            num /= 10;
        }
        return ans;
    }
}