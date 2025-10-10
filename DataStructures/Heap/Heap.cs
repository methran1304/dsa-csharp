namespace DS;

// MaxHeap
public class HeapImplementation
{
    private List<int> _data;

    public HeapImplementation()
    {
        _data = [];
    }

    public bool Insert(int value)
    {
        _data.Add(value);

        // trickle up
        return TrickleUp(LastIndex);
    }

    private bool TrickleUp(int currentIndex)
    {
        if (currentIndex == 0) return true;

        int parentIndex = ParentIndex(currentIndex);

        if (_data[parentIndex] < _data[currentIndex])
        {
            (_data[parentIndex], _data[currentIndex]) = (_data[currentIndex], _data[parentIndex]);
            return TrickleUp(parentIndex);
        }

        return true;
    }

    private bool TrickleDown(int currentIndex)
    {
        int leftChildIndex = LeftChildIndex(currentIndex);
        int rightChildIndex = RightChildIndex(currentIndex);

        // has two children
        if (leftChildIndex < _data.Count && rightChildIndex < _data.Count)
        {
            // swap and traverse to left
            if (_data[leftChildIndex] > _data[rightChildIndex] && _data[leftChildIndex] > _data[currentIndex])
            {
                (_data[currentIndex], _data[leftChildIndex]) = (_data[leftChildIndex], _data[currentIndex]);
                return TrickleDown(leftChildIndex);
            }
            // swap and traverse to right
            if (_data[leftChildIndex] < _data[rightChildIndex] && _data[rightChildIndex] > _data[currentIndex])
            {
                (_data[currentIndex], _data[rightChildIndex]) = (_data[rightChildIndex], _data[currentIndex]);
                return TrickleDown(rightChildIndex);
            }

            if (_data[leftChildIndex] == _data[rightChildIndex] && _data[leftChildIndex] > _data[currentIndex])
            {
                (_data[currentIndex], _data[leftChildIndex]) = (_data[leftChildIndex], _data[currentIndex]);
                return TrickleDown(leftChildIndex);
            }
        }
        // only left child
        else if (leftChildIndex < _data.Count)
        {
            if (_data[leftChildIndex] > _data[currentIndex])
            {
                (_data[currentIndex], _data[leftChildIndex]) = (_data[leftChildIndex], _data[currentIndex]);
                return TrickleDown(leftChildIndex);
            }
        }
        // only right child
        else if (rightChildIndex < _data.Count)
        {
            if (_data[rightChildIndex] > _data[currentIndex])
            {
                (_data[currentIndex], _data[rightChildIndex]) = (_data[rightChildIndex], _data[currentIndex]);
                return TrickleDown(rightChildIndex);
            }
        }
        return true;
    }

    public bool Delete()
    {
        // no element to delete
        if (_data.Count == 0) return false;

        _data[0] = _data[LastIndex];
        _data.RemoveAt(LastIndex);

        // trickle down from root element
        return TrickleDown(0);
    }

    public int? Root => _data.Count > 0 ? _data[0] : null;
    private int LastIndex => _data.Count - 1;
    private int LeftChildIndex(int currentIndex) => (2 * currentIndex) + 1;
    private int RightChildIndex(int currentIndex) => (2 * currentIndex) + 2;
    private int ParentIndex(int currentIndex) => (currentIndex - 1) / 2;
}

public static class Heap
{
    public static void Begin()
    {
        HeapImplementation heap = new();
        heap.Insert(200);
        heap.Insert(100);
        heap.Insert(150);
        heap.Insert(350);
        heap.Insert(550);
        Console.WriteLine(heap.Root);
        heap.Delete();
        Console.WriteLine(heap.Root);
    }
}
