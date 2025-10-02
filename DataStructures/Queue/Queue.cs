using System.ComponentModel;
namespace DS;

public class QueueImplementation<T>
{
    private LLImplementation<T> List { get; set; }
    public uint Count => List.Count;

    public QueueImplementation()
    {
        List = new();
    }

    public QueueImplementation(T? Value) : this()
    {
        Enqueue(Value);
    }

    public bool Enqueue(T? value)
    {
        List.InsertAtTail(value);
        return true;
    }

    public bool Dequeue()
    {
        if (List.Count == 0) return false;
        List.DeleteAtHead();
        return true;
    }

    public T? GetFront()
    {
        return List.GetHead();
    }

    public T? GetBack()
    {
        return List.GetTail();
    }

    public bool IsEmpty()
    {
        return List.Count == 0;
    }

    public void Traverse()
    {
        Console.Write("Front ");
        foreach (T element in List)
        {
            Console.Write($"{element} ");
        }
        Console.Write("Back \n");
    }
}

public static class Queue
{
    public static void Begin()
    {
        QueueImplementation<int> queueImplementation = new();

        queueImplementation.Enqueue(1);
        queueImplementation.Enqueue(2);
        queueImplementation.Enqueue(3);
        queueImplementation.Enqueue(4);


        queueImplementation.Traverse();

        queueImplementation.Dequeue();

        queueImplementation.Traverse();

        queueImplementation.Enqueue(20);

        queueImplementation.Traverse();
    }
}
