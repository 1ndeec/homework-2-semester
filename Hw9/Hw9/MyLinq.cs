// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw9;

using System.Collections;

/// <summary>
/// implements GetPrimes method which returns eternal sequence of prime numbers, also implements two extension methods Skip and Take.
/// </summary>
public static class MyLinq
{
    /// <summary>
    /// returns eternal sequence of prime numbers.
    /// </summary>
    /// <returns> eternal sequence of prime numbers. </returns>
    public static IEnumerable<int> GetPrimes()
    {
        return new PrimeEnumerable();
    }

    /// <summary>
    /// Extension method which allows to skip some number of first elements in sequence.
    /// </summary>
    /// <typeparam name="T"> sequence elements` data type.</typeparam>
    /// <param name="seq"> sequence to skip first elements in. </param>
    /// <param name="start"> number of elements to skip. </param>
    /// <returns> sequence with number of skipped first elements. </returns>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int start)
    {
        return new SkipEnumerable<T>(seq, start);
    }

    /// <summary>
    /// Extension method which allows to take some number of first elements from sequence.
    /// </summary>
    /// /// <typeparam name="T"> sequence elements` data type.</typeparam>
    /// <param name="seq"> sequence to take first elements from. </param>
    /// <param name="end"> number of elements to take. </param>
    /// <returns> sequence of taken elements. </returns>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int end)
    {
        return new TakeEnumerable<T>(seq, end);
    }

    private class SkipEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> sourceEnumerable;
        private readonly int start;

        public SkipEnumerable(IEnumerable<T> sourceEnumerable, int start)
        {
            this.sourceEnumerable = sourceEnumerable;
            this.start = start;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SkipEnumerator<T>(this.sourceEnumerable.GetEnumerator(), this.start);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    private class SkipEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> sourceEnumerator;
        private readonly int start;

        public SkipEnumerator(IEnumerator<T> sourceEnumerator, int start)
        {
            this.sourceEnumerator = sourceEnumerator;
            this.start = start;

            for (int i = 0; i < start && sourceEnumerator.MoveNext(); i++)
            {
            }
        }

        public T Current => this.sourceEnumerator.Current;

        object IEnumerator.Current => this.Current!;

        public bool MoveNext()
        {
            return this.sourceEnumerator.MoveNext();
        }

        public void Reset() => throw new NotSupportedException();

        public void Dispose() => this.sourceEnumerator.Dispose();
    }

    private class TakeEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> sourceEnumerable;
        private readonly int end;

        public TakeEnumerable(IEnumerable<T> sourceEnumerable, int end)
        {
            this.sourceEnumerable = sourceEnumerable;
            this.end = end;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new TakeEnumerator<T>(this.sourceEnumerable.GetEnumerator(), this.end);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    private class TakeEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> sourceEnumerator;
        private readonly int end;
        private int index;

        public TakeEnumerator(IEnumerator<T> sourceEnumerator, int end)
        {
            this.sourceEnumerator = sourceEnumerator;
            this.end = end;
            this.index = 0;
        }

        public T Current => this.sourceEnumerator.Current;

        object IEnumerator.Current => this.Current!;

        public bool MoveNext()
        {
            while (this.index < this.end)
            {
                this.index++;
                return this.sourceEnumerator.MoveNext();
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();

        public void Dispose() => this.sourceEnumerator.Dispose();
    }

    private class PrimeEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new PrimeEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    private class PrimeEnumerator : IEnumerator<int>
    {
        private int current = 1;

        public int Current => this.current;

        object IEnumerator.Current => this.current;

        public bool MoveNext()
        {
            do
            {
                this.current++;
            }
            while (!IsPrime(this.current));
            return true;
        }

        public void Reset()
        {
            this.current = 1;
        }

        public void Dispose()
        {
        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
