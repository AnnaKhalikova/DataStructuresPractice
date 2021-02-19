using System;
using System.Collections;
using System.Collections.Generic;

namespace QueuePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Queue<int> queue = CreateQueue(4, -10, 5, 7, 48, 9, 10);
            Console.WriteLine("The max element: " + FindMaxElementInQueue(queue));
            Console.WriteLine("The min element: " + FindMinElementInQueue(queue));
            Console.WriteLine("Result of calculating: " + CalculateAmount(queue));
        }
        static Queue<int> CreateQueue(params int[] numbers)
        {
            Queue<int> queue = new Queue<int>();
            foreach(var elements in numbers)
            {
                queue.Enqueue(elements);
            }
            return queue;
        }
        static ArrayList CreateArrayFromQueue(Queue<int> queue)
        {
            ArrayList listOfNumbersFromQueue = new ArrayList();

            listOfNumbersFromQueue.AddRange(queue);
   
            return listOfNumbersFromQueue;
        }
        static int FindMaxElementInQueue(Queue<int> queue)
        {
            int imax = 0;
            ArrayList list = CreateArrayFromQueue(queue);
            for(int i = 0; i < list.Count; i++)
            {
                if((int)list[i] > (int)list[imax])
                    imax = i;
            }
                
            return imax;
        }
        static int FindMinElementInQueue(Queue<int> queue)
        {
            int imin = 0;
            ArrayList list = CreateArrayFromQueue(queue);
            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list[i] < (int)list[imin])
                    imin = i;
            }
            return imin;
        }
        static int CalculateAmount(Queue<int> queue)
        {
            ArrayList list = CreateArrayFromQueue(queue);
            int result = 0, imin = FindMinElementInQueue(queue), imax = FindMaxElementInQueue(queue);
            if(imin > imax)
            {
                int temp = imin;
                imin = imax;
                imax = temp;
            }
            for(int i = imin; i <= imax; i++)
            {
                result += (int)list[i];
            }

            return result;
        }
    }
}
