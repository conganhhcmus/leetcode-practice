public class ConvexHullTrick
{
    private struct Line
    {
        public long M, C;
        public long Eval(long x) => M * x + C;

        // Using decimal for intersection to avoid precision issues with double
        public decimal IntersectX(Line other)
        {
            return (decimal)(other.C - C) / (M - other.M);
        }
    }

    private Line[] _dq;
    private int _head;
    private int _tail;

    public ConvexHullTrick(int maxSize)
    {
        _dq = new Line[maxSize + 1];
        _head = 0;
        _tail = -1;
    }

    /// <summary>
    /// Adds a line y = mx + c to the hull. 
    /// Assumes slopes are added in strictly decreasing order.
    /// </summary>
    public void AddLine(long m, long c)
    {
        Line newLine = new Line { M = m, C = c };

        while (_tail - _head >= 1)
        {
            if (newLine.IntersectX(_dq[_tail]) <= _dq[_tail].IntersectX(_dq[_tail - 1]))
            {
                _tail--;
            }
            else
            {
                break;
            }
        }
        _dq[++_tail] = newLine;
    }

    /// <summary>
    /// Queries the minimum y-value for a given x.
    /// Assumes x-queries are strictly increasing.
    /// </summary>
    public long Query(long x)
    {
        if (_tail < _head) throw new InvalidOperationException("Hull is empty");

        while (_tail - _head >= 1)
        {
            if (_dq[_head].Eval(x) >= _dq[_head + 1].Eval(x))
            {
                _head++;
            }
            else
            {
                break;
            }
        }
        return _dq[_head].Eval(x);
    }
}
