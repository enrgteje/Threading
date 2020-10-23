using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many darts will be thrown each thread?");
            int threadCount = Convert.ToInt32(Console.ReadLine());
            List<Thread> b = new List<Thread>(threadCount);
            List<FindPiThread> c = new List<FindPiThread>(threadCount);
            for(int i = 0; i < threadCount; i++)
            {
                FindPiThread a = new FindPiThread(threadCount);
            }
        }
    }
}
