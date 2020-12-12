using System;
using System.Collections.Generic;
using System.Text;

namespace SinglyCircularLinkedList
{
    class SinglyCircularLinkedList
    {
        public Node Tail;
        private int count = 0;

        public int GetCount()
        {
            return count;
        }
		public void Print()
		{
			if (count == 0)
			{
				return;
			}

			Console.WriteLine(Print(Tail.Next));
		}
		public string Print(Node node)
		{
			if (count == 0)
			{
				return string.Empty;
			}
			string result = "";
			Node current = node;
			do
			{
				result += current.Value + " ";
				current = current.Next;
			} while (current != node);

			return result;
		}
		public Node Find(int key)
		{
			if (count == 0)
			{
				return null;
			}
			Node current = Tail;
			do
			{
				if (current.Value == key)
				{
					return current;
				}
				current = current.Next;
			}
			while (current != Tail);
			return null;
		}
		public Node FindLast(int key)
		{
			if (count == 0)
			{
				return null;
			}
			if (Tail.Value == key) return Tail;
			Node current = Tail.Next;
			Node res = null;
			while (current != Tail)
			{
				if (current.Value == key) res = current;
				current = current.Next;
			}
			return res;
		}
		private void AddAfterInternal(Node node, Node newNode)
		{
			newNode.Next = node.Next;
			node.Next = newNode;
			count++;
		}
		private void InsertNodeToEmptyList(Node node)
		{
			node.Next = node;
			Tail = node;
			count++;
		}
		public void PushBack(int item)
		{
			Node newNode = new Node(item);

			if (count == 0)
			{
				InsertNodeToEmptyList(newNode);
			}
			else
			{
				AddAfterInternal(Tail, newNode);
				Tail = newNode;
			}
		}
		public void PushFront(int item)
		{
			Node newNode = new Node(item);
			if (count == 0)
			{
				InsertNodeToEmptyList(newNode);
			}
			else
			{
				AddAfterInternal(Tail, newNode);
			}
		}
		public void AddAfter(Node node, int item)
		{
			Node newNode = new Node(item);

			AddAfterInternal(node, newNode);
			if (node == Tail)
			{
				Tail = newNode;
			}
		}
		public void AddBefore(Node node, int item)
		{
			Node current = Tail;
			while (current.Next != node)
			{
				current = current.Next;
			}
			if (current != Tail) AddAfter(current, item);
			else PushFront(item);
		}
		private void RemoveAfterNodeInternal(Node node)
		{
			if (count == 0)
			{
				throw new Exception("Список пуст");
			}

			if (count == 1)
			{
				Tail = null;
			}
			else
			{
				if (node.Next == Tail)
				{
					Tail = node;
				}

				node.Next = node.Next.Next;
			}

			count--;
		}
		public void RemoveFirst()
		{
			RemoveAfterNodeInternal(Tail);
		}
		public void RemoveNode(Node node)
		{
			if (count == 0)
			{
				throw new Exception("Список пуст");
			}

			Node current = node;
			while (current.Next != node)
			{
				current = current.Next;
			}

			RemoveAfterNodeInternal(current);
		}
		public void RemoveLast()
		{
			RemoveNode(Tail);
		}
		public bool Remove(int item)
		{
			if (count == 0)
			{
				return false;
			}
			Node res = Find(item);
			if (res != null)
			{
				RemoveNode(res);
				return true;
			}
			return false;
		}
		public bool RemoveLast(int item)
		{
			if (count == 0)
			{
				return false;
			}
			Node res = Find(item);
			if (res == null) return false;
			Node current = Tail.Next;
			while (current != Tail)
			{
				if (current.Value == item) res = current;
				current = current.Next;
			}
			RemoveNode(res);
			return true;
		}
	}
}
