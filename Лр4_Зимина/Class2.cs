using System.Numerics;

namespace ConsoleApp3
{
    public class Node
    {
        public string PlaceOfBorn;
        public BigInteger PassportNumber;
        public string Propiska;
        public Node Next;

        public Node(string placeOfBorn, BigInteger passport_number, string propiska)
        {
            PlaceOfBorn = placeOfBorn;
            PassportNumber = passport_number;
            Propiska = propiska;
            Next = null;
        }
    }

    public class StackList
    {
        private Node head;

        public StackList()
        {
            head = null;
        }

        public void AddNode(string placeOfBorn, BigInteger passport_number, string propiska)
        {
            // Добавление узла в начало (вершину стека)
            Node newNode = new Node(placeOfBorn, passport_number, propiska);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        public Node GetNode()
        {
            // Получение первого узла
            return head;
        }

        public void RemoveNode()
        {
            // Удаление узла из начала (вершины стека)
            if (head == null)
            {
                Console.WriteLine("Стек пуст, удаление невозможно!");
            }
            else
            {
                head = head.Next;
            }
        }

        public void Reverse()
        {
            if (head == null || head.Next == null)
                return;

            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;  // Сохраняем следующий узел
                current.Next = prev;   // Разворачиваем ссылку
                prev = current;        // Двигаем prev
                current = next;        // Двигаем current
            }

            head = prev; // Новый head - последний обработанный узел
        }

        public void PrintStack()
        {
            // Вывод стека
            if (head == null)
            {
                Console.WriteLine("{}");
            }

            else if (head != null && head.Next == null)
            {
                Console.WriteLine("{Дата и место рождения: " + head.PlaceOfBorn + ", Серия и номер паспорта: " + head.PassportNumber + ", Место прописки:" + head.Propiska + "}");
            }

            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    Console.WriteLine("{Дата и место рождения: " + current.PlaceOfBorn + ", Серия и номер паспорта: " + current.PassportNumber + ", Место прописки:" + current.Propiska + "}");
                    current = current.Next;
                }
                Console.WriteLine("{Дата и место рождения: " + current.PlaceOfBorn + ", Серия и номер паспорта: " + current.PassportNumber + ", Место прописки:" + current.Propiska + "}");

            }
        }

        public void Clear()
        {
            // Очистка стека
            head = null;
        }

        public void Check()
        {
            // Проверка стека на пустоту
            if (head != null)
                Console.WriteLine("Стек не пустой");
            else
                Console.WriteLine("Стек пустой");
        }
    }
}