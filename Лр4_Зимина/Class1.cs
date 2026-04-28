namespace ConsoleApp4
{
    public class Node
    {
        public int Value;      // Значение
        public Node Next;     // Ссылка
        public Node Prev;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class DeckList
    {
        private Node head;

        public DeckList()
        {
            head = null;
        }

        public void AddNodeFirst(int data)
        {
            // Добавление в начало
            Node new_node = new Node(data);
            new_node.Next = head;
            head = new_node;
        }

        public void AddBack(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool CheckEmpty()
        {
            if (head == null) return false;
            else return true;
        }

        public int GetFirstNode()
        {
            // получение первого элемента дека
            if (head == null) return -1;
            else return head.Value;
        }

        public int GetLastNode()
        {
            // Получение последнего элемента 
            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public void RemoveNodeStart()
        {
            // Удаление узла из начала
            if (head == null)
            {
                return;
            }

            if (head.Next == null) // Если в деке только один элемент
            {
                head = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
        }

        public void RemoveNodeLast()
        {
            // Удаление узла из конца

            if (head == null)
            {
                return;
            }

            if (head.Next == null)
            {
                head = null;
                return;
            }

            Node current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public void Clear()
        {
            // Очистака декв
            head = null;
        }

        public void PrintDeck()
        {
            // Вывод дека
            Node current = head;

            if (current != null)
            {
                while (current != null)
                {
                    Console.Write("[");
                    Console.Write(current.Value);

                    current = current.Next;

                    if (current != null)
                    {
                        Console.Write(" -> ");
                        Console.Write(current.Value);
                        Console.Write("] - ");
                    }
                    else
                    {
                        Console.Write("]");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            else Console.WriteLine("[]");
        }

    }
}