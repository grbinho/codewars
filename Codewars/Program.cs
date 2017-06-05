using System;
using System.Diagnostics;

namespace Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var res = RemovedNumbers.removNb(5);

            timer.Stop();
            Console.WriteLine($"Result {res} in {timer.ElapsedMilliseconds} ms");
        }
    }
}
