using System.Collections;
using System.Collections.Generic;

namespace app1
{
    public class ListaGen<T> : IEnumerable<T>
    {
        private class Nod
        {
            public Nod? Next { get; set; }
            public T Data { get; set; }

            public Nod(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Nod? Inceput { get; set; }
        public uint Count { get; private set; }

        public ListaGen()
        {
            Inceput = null;
            Count = 0;
        }

        public void Add(T element)
        {
            Nod n = new Nod(element);
            n.Next = Inceput;
            Inceput = n;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nod? current = Inceput;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
