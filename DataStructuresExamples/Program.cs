using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello user!\n This program finds the equal elements in two stacks" +
                " and put these in the result stack. Wait a second...");
            Stack<int> firstStack = CreateStack<int>(9, 3, 8, 3, 1, 1);
            Stack<int> secondStack = CreateStack<int>(7, 8, 3, 2, 0, 1, 4);
            Stack<int> resultStack = FindEqualElementsInStacks(firstStack, secondStack);
            PrintElementsInStack(resultStack);
        }
        static Stack<T> CreateStack<T>(params T[] array)
        {
            Stack<T> stack = new Stack<T>();
            foreach(var element in array)
            {
                stack.Push(element);
            }

            return stack;
        }
        static ArrayList CreateArrayWithDidgits<T>(Stack<T> stack)
        {
            ArrayList digitsList = new ArrayList();

            digitsList.AddRange(stack);

            return digitsList;
        }
        static Stack<int> FindEqualElementsInStacks(Stack<int> firstStack, Stack<int> secondStack)
        {
            ArrayList firstList = CreateArrayWithDidgits<int>(firstStack);
            ArrayList secondList = CreateArrayWithDidgits<int>(secondStack);
            Stack<int> resultStack = new Stack<int>();

            foreach(var digit in firstList)
            {
                if (secondList.Contains(digit))
                {
                    resultStack.Push((int)digit);
                }
            }
            return resultStack;
        }
        static void PrintElementsInStack<T>(Stack<T> stack)
        {
            foreach(var element in stack)
            {
                Console.Write(element + " ");
            }
        }
    }
}
