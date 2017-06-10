using System;
using System.Collections.Generic;
using System.Linq;

/*
    A Stream is an infinite sequence of items. It is defined recursively
    as a head item followed by the tail, which is another stream.
    Consequently, the tail has to be wrapped with Lazy to prevent
    evaluation.
*/

namespace Codewars
{
    public class Stream<T>
    {
        public readonly T Head;
        public readonly Lazy<Stream<T>> Tail;

        public Stream(T head, Lazy<Stream<T>> tail)
        {
            Head = head;
            Tail = tail;
        }
    }

    public static class Stream
    {
        /*
            Your first task is to define a utility function which constructs a
            Stream given a head and a function returning a tail.
        */
        public static Stream<T> Cons<T>(T h, Func<Stream<T>> t)
        {
            return new Stream<T>(h, new Lazy<Stream<T>>(t));            
        }

        // .------------------------------.
        // | Static constructor functions |
        // '------------------------------'

        // Construct a stream by repeating a value.
        public static Stream<T> Repeat<T>(T x)
        {
            return Cons(x, () => Repeat(x));          
        }

        // Construct a stream by repeatedly applying a function.
        public static Stream<T> Iterate<T>(Func<T, T> f, T x)
        {
            return Cons(x, () => Iterate(f,f(x)));            
        }

        // Construct a stream by repeating an enumeration forever.
        public static Stream<T> Enumerate<T>(IEnumerator<T> a)
        {   
            return Cons(a.Current, () => {                
                if (a.MoveNext()) return Enumerate(a);
                else {
                    a.Reset();
                    a.MoveNext();                    
                    return Enumerate(a);             
                }                
            });                                
        }     

        public static Stream<T> Cycle<T>(IEnumerable<T> a)
        {    
            var e = a.ToList().GetEnumerator();
            e.MoveNext();
            return Enumerate(e);           
        }

        // Construct a stream by counting numbers starting from a given one.
        public static Stream<int> From(int x)
        {
            return Iterate((n) => n+1, x);            
        }
        
        // Same as From but count with a given step width.
        public static Stream<int> FromThen(int x, int d)
        {
            return Iterate((n) => n+d, x);
        }

        // .------------------------------------------.
        // | Stream reduction and modification (pure) |
        // '------------------------------------------'

        /*
            Being applied to a stream (x1, x2, x3, ...), Foldr shall return
            f(x1, f(x2, f(x3, ...))). Foldr is a right-associative fold.
            Thus applications of f are nested to the right.
        */
        public static U Foldr<T,U>(this Stream<T> s, Func<T, Func<U>, U> f)
        {
            return f(s.Head, () => s.Tail.Value.Foldr(f));          
        }

        // Filter stream with a predicate function.
        public static Stream<T> Filter<T>(this Stream<T> s, Predicate<T> p)
        {
            if(p(s.Head)) return Cons(s.Head, () => s.Tail.Value.Filter(p));
            else return s.Tail.Value.Filter(p);
        }

        // Returns a given amount of elements from the stream.
        public static IEnumerable<T> Take<T>(this Stream<T> s, int n)
        {
            for(var i = 0; i<n; i++){
                yield return s.Head;
                s = s.Tail.Value;
            }            
        }

        // Drop a given amount of elements from the stream.
        public static Stream<T> Drop<T>(this Stream<T> s, int n)
        {
            if(n > 0) return s.Tail.Value.Drop(n-1);
            return s;            
        }

        // Combine 2 streams with a function.
        public static Stream<R> ZipWith<T, U, R>(this Stream<T> s, Func<T, U, R> f, Stream<U> other)
        {
            return Cons(f(s.Head, other.Head), () => s.Tail.Value.ZipWith(f,other.Tail.Value));            
        }

        // Map every value of the stream with a function, returning a new stream.
        public static Stream<U> FMap<T, U>(this Stream<T> s, Func<T, U> f)
        {
            return Cons(f(s.Head), () => s.Tail.Value.FMap(f));            
        }

        // Return the stream of all fibonacci numbers.
        // 1, 1, 2, 3, 5, 8, ..
        // n+1 = n + n-1

        private static int Fib(long n)
        {
            if(n == 1) return 0;
            if(n == 2) return 1;
            return Fib(n-1) + Fib(n-2);
        }
        public static Stream<int> Fib()
        {                        
            return Stream.From(1).FMap((n) => Fib(n));          
        }

        // Return the stream of all prime numbers.
        private static bool IsPrime(long n)
        {
            if (n == 1) return false;
            if (n == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 2; i <= boundary; ++i)
            {
                if (n % i == 0)  return false;
            }

            return true;
        }
        public static Stream<int> Primes()
        {
            return Stream.From(2).Filter((n) => IsPrime(n));            
        }
    }
}