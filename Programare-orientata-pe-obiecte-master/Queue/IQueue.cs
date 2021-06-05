using System;

namespace Queue
{
    public interface IQueue<T>
    {
        public void Enqueue(T item);
        public T Dequeue();
        public T Peek();
        public bool IsEmpty { get; }
        public int Count { get; }
    }

    public class QueueEmptyException : InvalidOperationException
    {
        internal QueueEmptyException() : base("Queue is empty.") { }

        internal QueueEmptyException(string message) : base(message) { }
    }

    public class QueueFullException : InvalidOperationException
    {
        internal QueueFullException() : base("Queue is full.") { }

        internal QueueFullException(string message) : base(message) { }
    }
}
