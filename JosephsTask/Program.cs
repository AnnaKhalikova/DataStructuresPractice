using System;
using System.Collections;
using System.Collections.Generic;

namespace JosephsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = FillList(41);
            Console.Write("Init state of list: ");
            PrintList(linkedList);
            Console.WriteLine("\nThe last of us: " + FindTheLastOfAlive(linkedList));
        }
        static CircularLinkedList<int> FillList(int numberOfHumans)
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            int i = 1;
            while (i <= numberOfHumans)
            {
                list.Add(i);
                i++;
            }
            return list;
        }
        static int FindTheLastOfAlive(CircularLinkedList<int> listOfHumans)
        { 
            int number = 0, step = 2, startPosition = 1;
            for(int i = 1; i <= listOfHumans.Count; i++)
            {
                number = (number + step) % i;
            }
            return number + 1;
        }
        static void PrintList(CircularLinkedList<int> list)
        {
            foreach(var element in list)
            {
                Console.Write(element + " ");
            }
        }
    }
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        public Node<T> head; // Main head element
        public Node<T> tail; // The last(tail) element
        int count;  // number of elements in the list

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            // if our list is empty
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если узел последний,
                        // изменяем переменную tail
                        if (current == tail)
                            tail = previous;
                    }
                    else // если удаляется первый элемент
                    {

                        // если в списке всего один элемент
                        if (count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != head);

            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
