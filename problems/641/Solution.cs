namespace Problem_641;

public class MyCircularDeque
{
    public class DoubleLinkedList
    {
        public DoubleLinkedList(int value)
        {
            Value = value;
            Previous = Next = null;
        }
        public int Value { get; set; }
        public DoubleLinkedList Previous { get; set; }
        public DoubleLinkedList Next { get; set; }
    }
    private readonly int _maxLength;
    private int _currentLength;
    private DoubleLinkedList _list = null;
    private DoubleLinkedList _head = null;
    private DoubleLinkedList _tail = null;

    public MyCircularDeque(int k)
    {
        _maxLength = k;
        _currentLength = 0;
        _head = _tail = _list = null;
    }

    public bool InsertFront(int value)
    {
        if (_list is null)
        {
            _head = _tail = _list = new DoubleLinkedList(value);
            _currentLength++;
            return true;
        }

        if (_currentLength >= _maxLength) return false;

        var newNode = new DoubleLinkedList(value);
        newNode.Next = _head;
        _head.Previous = newNode;
        _head = newNode;
        _currentLength++;
        return true;
    }

    public bool InsertLast(int value)
    {
        if (_list is null)
        {
            _head = _tail = _list = new DoubleLinkedList(value);
            _currentLength++;
            return true;
        }

        if (_currentLength >= _maxLength) return false;

        var newNode = new DoubleLinkedList(value);
        newNode.Previous = _tail;
        _tail.Next = newNode;
        _tail = newNode;
        _currentLength++;
        return true;
    }

    public bool DeleteFront()
    {
        if (_head is null) return false;
        _currentLength--;

        if (_currentLength == 0)
        {
            _head = _tail = _list = null;
            return true;
        }

        _head = _head.Next;
        if (_head is not null)
        {
            _head.Previous = null;
        }

        return true;
    }

    public bool DeleteLast()
    {
        if (_tail is null) return false;
        _currentLength--;

        if (_currentLength == 0)
        {
            _head = _tail = _list = null;
            return true;
        }

        _tail = _tail.Previous;
        if (_tail is not null)
        {
            _tail.Next = null;
        }
        return true;
    }

    public int GetFront()
    {
        if (_head is null) return -1;
        return _head.Value;
    }

    public int GetRear()
    {
        if (_tail is null) return -1;
        return _tail.Value;
    }

    public bool IsEmpty()
    {
        return _currentLength == 0;
    }

    public bool IsFull()
    {
        return _currentLength == _maxLength;
    }
}

public class Solution
{
    public static void Execute()
    {
        string[] actions = ["MyCircularDeque", "insertFront", "getFront", "isEmpty", "deleteFront", "insertLast", "getRear", "insertLast", "insertFront", "deleteLast", "insertLast", "isEmpty"];
        int[][] values = [[8], [5], [], [], [], [3], [], [7], [7], [], [4], []];
        List<string> result = [];

        MyCircularDeque circularDeque = new(0);

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MyCircularDeque":
                    circularDeque = new MyCircularDeque(values[i][0]);
                    result.Add("null");
                    break;
                case "insertLast":
                    result.Add(circularDeque.InsertLast(values[i][0]).ToString());
                    break;
                case "insertFront":
                    result.Add(circularDeque.InsertFront(values[i][0]).ToString());
                    break;
                case "getRear":
                    result.Add(circularDeque.GetRear().ToString());
                    break;
                case "isFull":
                    result.Add(circularDeque.IsFull().ToString());
                    break;
                case "deleteLast":
                    result.Add(circularDeque.DeleteLast().ToString());
                    break;
                case "getFront":
                    result.Add(circularDeque.GetFront().ToString());
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"[{string.Join(",", result)}]");
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */