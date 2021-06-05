namespace Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        Node Head = null;
        Node Tail = null;
        public int Count { get; private set; }

        private class Node
        {
            public T Value { get; }
            public Node Next { get; internal set; }

            public Node(Node next, T value)
            {
                Next = next;
                Value = value;
            }
        }

        public LinkedQueue()
        {
            Count = 0;
        }

        public void Enqueue(T item)
        {
            Node node = new(null, item);
            Count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
            }

            else
            {
                Tail.Next = node;
                Tail = node;
            }
        }

        public T Dequeue()
        {
            if (Head == null)
                throw new QueueEmptyException();

            T item = Head.Value;
            Head = Head.Next;

            return item;
        }

        public T Peek()
        {
            if (Head == null)
                throw new QueueEmptyException();

            return Head.Value;
        }

        public bool IsEmpty => Count == 0;
    }
}
