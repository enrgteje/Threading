/* Name: Enrique Tejeda
 * Date: 10/26/2020
 * Filename: Program.cs
 * Description: Program asks the user how many darts will be thrown along with how many threads they want to use for the program to find pi. Program calls FindPiThread's
 *              throwDarts function to find how many darts landed in the target so that it can be used to calculate pi. Program also adds the threads depending on how many the user requests.
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            int dartsLanded = 0;
            int totalDarts = 0;

            Console.WriteLine("How many darts will be thrown each thread?");
            int dartsPerThread = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many threads will you want?");
            int threadCount = Convert.ToInt32(Console.ReadLine());

            //Creating the threads
            List<Thread> threadList = new List<Thread>(threadCount);
            List<FindPiThread> piList = new List<FindPiThread>(threadCount);

            for(int i = 0; i < threadCount; i++)
            {
                FindPiThread piThread = new FindPiThread(dartsPerThread);
                piList.Add(piThread);
                Thread myThread = new Thread(new ThreadStart(piThread.throwDarts));
                threadList.Add(myThread);
                myThread.Start();
                Thread.Sleep(16);
            }
            for(int i = 0; i < threadList.Count; i++)
            {
                threadList[i].Join();
            }
            for(int i = 0; i < piList.Count; i++)
            {
                dartsLanded += piList[i].dartsLandedAccessor;
            }
            totalDarts = dartsPerThread * threadCount;
            double pi = 4.0 * ((double)dartsLanded / (double)totalDarts);
            Console.WriteLine("The number of darts in the target are: " + dartsLanded);
            Console.WriteLine("The total number of darts were: " + totalDarts);
            Console.WriteLine("Pi is: " + pi);
        }
    }
}
