using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>, IQueue<T>
    {
        T[] Data;
        readonly int Capacity = 10;
        public int Count { get; private set; }
        int Left = 0, Right = 0;

        public Queue()
        {
            Data = new T[Capacity];
        }
        public Queue(int capacity)
        {
            Capacity = capacity;
            Data = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (IsFull)
                throw new QueueFullException();

            Count++;
            Data[Right % Capacity] = item;
            Right = (Right + 1) % Capacity;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new QueueEmptyException();

            Count--;
            int oldLeft = Left;
            Left = (Left + 1) % Capacity;

            return Data[oldLeft % Capacity];
        }

        public T Peek()
        {
            if(IsEmpty)
                throw new QueueEmptyException();

            return Data[Left];
        }

        public bool IsFull => Count == Capacity;

        public bool IsEmpty => Count == 0;


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Left; i < Right; i++)
                yield return Data[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
