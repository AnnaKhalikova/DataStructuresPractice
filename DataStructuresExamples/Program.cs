using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello user!\nThis program finds the equal elements in two stacks" +
                " and put these in the result stack. Wait a second...");
            //Let's create two stacks with Generic Collection Stack<T>, T means that we can put some data type
            //(for example int in our program) and that describes what type of element kept in our stack 
            Stack<int> firstStack = CreateStack<int>(9, 3, 8, 3, 1, 1);
            Stack<int> secondStack = CreateStack<int>(7, 8, 3, 2, 0, 1, 4);
            //and one another stack for keeping resulting set
            Stack<int> resultStack = FindEqualElementsInStacks(firstStack, secondStack);
            PrintElementsInStack(resultStack);// 
        }
        //This methods helps us create different stacks from the set of numbers
        //For example you can see at 15 and 16 lines how we put different number of elements in this method
        //To implement it we use key word PARAMS, read more about it, please:)
        static Stack<T> CreateStack<T>(params T[] array)
        {
            //Now let's create stack again..
            Stack<T> stack = new Stack<T>();
            //Because stack implement IEnumerable interface
            //we can use the foreach loop to iterate over the stack
            //and add our elements in stack with Push() method
            foreach (var element in array)
            {
                stack.Push(element);
            }
            //and, of course, we should return our stack:)
            return stack;
        }
        //Now let's create methods, that pop our elements from stack into ArrayList collection...
        static ArrayList CreateArrayWithDidgits<T>(Stack<T> stack)
        {
            ArrayList digitsList = new ArrayList();//First of all we should create ArrayList collection
            // and just add all elements from stack into our ArrayList with AddRange() method:)
            digitsList.AddRange(stack);

            return digitsList;//and return it again:)
        }
        //Now let's create the main methods with business logic of our app..
        static Stack<int> FindEqualElementsInStacks(Stack<int> firstStack, Stack<int> secondStack)
        {
            //First of all create all needed collections...
            ArrayList firstList = CreateArrayWithDidgits<int>(firstStack);
            ArrayList secondList = CreateArrayWithDidgits<int>(secondStack);
            Stack<int> resultStack = new Stack<int>();
            //Use Contains method to check if the second collection contains any elements of the first collection
            foreach (var digit in firstList)
            {
                if (secondList.Contains(digit))
                {
                    //and don't forget put this element in our resulting stack
                    resultStack.Push((int)digit);
                }
            }
            return resultStack;
        }
        //This methods helps us to print elements in the resulting stack on console
        static void PrintElementsInStack<T>(Stack<T> stack)
        {
            foreach(var element in stack)
            {
                Console.Write(element + " ");
            }
        }
    }
}
