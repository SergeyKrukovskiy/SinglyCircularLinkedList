using System;

namespace SinglyCircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyCircularLinkedList singlyCircularLinkedList = new SinglyCircularLinkedList();
            singlyCircularLinkedList.PushFront(1);
            singlyCircularLinkedList.PushFront(2);
            singlyCircularLinkedList.PushFront(3);
            singlyCircularLinkedList.PushFront(4);
            singlyCircularLinkedList.PushFront(5);
            singlyCircularLinkedList.PushFront(6);
            singlyCircularLinkedList.PushFront(7);
            singlyCircularLinkedList.PushFront(5);
            singlyCircularLinkedList.PushFront(8);
            singlyCircularLinkedList.Print();
            singlyCircularLinkedList.RemoveLast(5);
            singlyCircularLinkedList.Print();
        }
    }
}
