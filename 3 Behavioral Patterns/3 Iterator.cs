Iterator: Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
// C# interfaces IEnumerable<T> and IEnumerator<T>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // using traditional iterator implementation
            foreach(var i in new NaturalNumbers().Take(10))
                Console.WriteLine(i);

            // using yield return feature
            foreach(var i in GetNaturalNumbers().Take(10))
                Console.WriteLine(i);
        }

        static IEnumerable<int> GetNaturalNumbers()
        {
            var current = 0;

            while (current < int.MaxValue)
                yield return current++;

            yield return current;
        }
    }

    class NaturalNumbers : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator() => new NaturalNumbersIterator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class NaturalNumbersIterator : IEnumerator<int>
    {
        public NaturalNumbersIterator() => Reset();

        public int Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public void Reset() => Current = -1;

        public bool MoveNext()
        {
            if (Current == int.MaxValue)
                return false;

            Current++;
            return true;
        } 
    }
}
 