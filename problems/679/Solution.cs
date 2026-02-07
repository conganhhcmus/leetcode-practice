public class Solution
{
    public bool JudgePoint24(int[] cards)
    {
        List<double> candidates = [];
        foreach (int card in cards)
        {
            candidates.Add(card);
        }

        return Ok(candidates);
    }

    const double EPSILON = 1e-6;
    const double TARGET = 24.0;

    bool Ok(List<double> candidates)
    {
        if (candidates.Count == 1)
        {
            return Math.Abs(TARGET - candidates[0]) < EPSILON;
        }

        for (int i = 0; i < candidates.Count; i++)
        {
            for (int j = 0; j < candidates.Count; j++)
            {
                if (i == j) continue;
                List<double> next = [];
                // pick remaining except i and j
                for (int k = 0; k < candidates.Count; k++)
                {
                    if (k != i && k != j) next.Add(candidates[k]);
                }

                // try all operations
                foreach (double val in Compute(candidates[i], candidates[j]))
                {
                    next.Add(val);
                    if (Ok(next)) return true;
                    next.RemoveAt(next.Count - 1);
                }
            }
        }
        return false;
    }

    List<double> Compute(double a, double b)
    {
        List<double> res = [];
        res.Add(a + b);
        res.Add(a - b);
        res.Add(b - a);
        res.Add(a * b);
        if (Math.Abs(b) > EPSILON) res.Add(a / b);
        if (Math.Abs(a) > EPSILON) res.Add(b / a);
        return res;
    }
}