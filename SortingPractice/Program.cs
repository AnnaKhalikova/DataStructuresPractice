using System;
using System.Collections;

namespace SortingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = FillArray(10, 5, 7, 8, 1, 8, 15, -14, 4, -4, 1);
            Console.Write("Initial array state: ");
            PrintElementsInArray(array);

            Console.WriteLine();

            //DoBubbleSort(array);
            DoQuickSort(array, 0, (int)(array.Count - 1));

            Console.Write("After sorting array state: ");
            PrintElementsInArray(array);
        }
        static ArrayList FillArray(params int[] elements) {
            var list = new ArrayList();
            list.AddRange(elements);
            return list;
        }
        //The first sorting algorithm is the Bubble Sort.
        //This algorithm very simple, but must know!
        //Use Bubble sort, when you have collection with 100 or less elements in it
        //In other situation you should use another algorithm to get better speed of sorting
        //Please, read some articles on habr.com about O() notation
        static void DoBubbleSort(ArrayList array)
        {
            for(int i = 0; i < array.Count; i++)
            {
                for(int j = 0; j < (array.Count - i - 1); j++)
                {
                    if((int)array[j] > (int)array[j + 1])
                    {
                        int temp = (int)array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        static void DoQuickSort(ArrayList array, int l, int r)
        {
            int left = l, right = r, middle = (int)array[(left + right) / 2];

            while (left <= right)
            {
                while ((int)array[left] < middle)
                {
                    left++;
                }
                while ((int)array[right] > middle)
                {
                    right--;
                }   
                if (left <= right)
                {
                    int temp = (int)array[left];
                    array[left] = (int)array[right];
                    array[right] = temp;
          
                    left++;
                    right--;
                }
            }
            if (l < right)
                DoQuickSort(array, l, right);
            if (r > left)
                DoQuickSort(array, left, r);
        }

        static void PrintElementsInArray(ArrayList array)
        {
            foreach(var element in array)
            {
                Console.Write(element + " ");
            }
        }
    }
}
