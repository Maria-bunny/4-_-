using System;
using System.Numerics;
using ConsoleApp2;
using ConsoleApp3;
using ConsoleApp4;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {

        static int get_number(string message)
        {
            // Обработка ввода чисел
            int number = -1;
            bool flag = false;
            while (!flag)
            {
                Console.Write(message);
                string data = Console.ReadLine();
                try
                {
                    number = int.Parse(data);
                    flag = true;
                }
                catch
                {
                    Console.WriteLine("Введено не число!");
                }
            }
            return number;
        }

        static string get_text(string message)
        {
            // Получение текста
            bool flag = false;
            string text = "";
            while (!flag)
            {
                Console.WriteLine(message);
                text = Console.ReadLine();
                if (text.Length == 0)
                {
                    Console.WriteLine("Текст не введен");
                }
                else
                {
                    flag = true;
                }
            }
            return text;
        }

        static BigInteger getPassportData()
        {
            BigInteger number = -1;
            bool flag = false;
            while (!flag)
            {
                Console.Write("Ввежите серию и номер паспорта");
                string data = Console.ReadLine();
                try
                {
                    number = BigInteger.Parse(data);
                    flag = true;
                }
                catch
                {
                    Console.WriteLine("Введено не число!");
                }
            }
            return number;
        }

        // ###########################################################
        // Задание 1

        static void rebouildQueue(QueueList list)
        {
            // Разбиение очереди на 2, один положительные другой отрицательные
            QueueList list1 = new QueueList(); // положительные
            QueueList list2 = new QueueList(); // отрицательные
            bool flag = false;

            while (!flag)
            {
                bool empty = list.checkNode();
                if (!empty)
                {
                    int number = list.getNode();
                    if (number >= 0) list1.AddNode(number);
                    else list2.AddNode(number);

                    list.RemoveNode();
                }
                else
                {
                    flag = true;
                }
            }

            Console.WriteLine("положительные числа: ");
            list1.PrintQueue();
            Console.WriteLine("отрицательные числа: ");
            list2.PrintQueue();
        }


        // ############################################################
        // Задание 3
        static void generateNewDecks(DeckList deck)
        {
            // Создание двух новых деков, один с отричательными числами, другой с положительными
            DeckList belongZeroDeck = new DeckList(); // меньше нуля
            DeckList MoreZeroDeck = new DeckList(); // Больше нуля

            if (deck.CheckEmpty() == false)
            {
                Console.WriteLine("Дек пуст, добавьте элементы!");
            }
            else
            {
                bool flag = false;
                while (!flag)
                {
                    bool check_deck = deck.CheckEmpty();
                    if (check_deck == false) flag = true;
                    else
                    {
                        int elem = deck.GetFirstNode();
                        if (elem > 0) MoreZeroDeck.AddNodeFirst(elem);
                        else belongZeroDeck.AddNodeFirst(elem);

                        deck.RemoveNodeStart();
                    }
                }
                Console.WriteLine("Дек для чисел больше нуля");
                MoreZeroDeck.PrintDeck();
                Console.WriteLine("Дек для чисел меньше нуля");
                belongZeroDeck.PrintDeck();
            }
        }

        // ##############################################################

        static void Main(string[] args)
        {
            // Очередь ################################################
            bool flag = false;
            string text = @"Выберите действие
            1) Добавить элемент в очередь
            2) Удалить элемент из очереди
            3) Вывести очередь
            4) Очистить очередь
            5) Проверить очередь на пустоту
            6) Выполнить задание
            0) Выйти";

            QueueList queue = new QueueList();

            while (!flag)
            {
                int choice = get_number(text);
                if (choice == 1)
                {
                    int number = get_number("Введите число для добавления");
                    queue.AddNode(number);
                }
                else if (choice == 2) queue.RemoveNode();
                else if (choice == 3) queue.PrintQueue();
                else if (choice == 4) queue.Clear();
                else if (choice == 5) queue.Check();
                else if (choice == 6) rebouildQueue(queue);
                else if (choice == 0) flag = true;
                else
                {
                    Console.WriteLine("Введите номер из списка");
                }

            }

            // Стек ##################################################

            flag = false;
            text = @"Выберите действие
            1) Добавить элемент в стек
            2) Удалить элемент из стека
            3) Вывести стек
            4) Очистить стек
            5) Развернуть стек
            0) Выйти";

            StackList stack = new StackList();


            while (!flag)
            {
                int choice = get_number(text);
                if (choice == 1)
                {
                    string placeOfBorn = get_text("Введите дату и место рождения");
                    BigInteger passport_number = getPassportData();
                    string propiska = get_text("Введите место прописки");
                    stack.AddNode(placeOfBorn, passport_number, propiska);

                }
                else if (choice == 2) stack.RemoveNode();
                else if (choice == 3) stack.PrintStack();
                else if (choice == 4) stack.Clear();
                else if (choice == 5) stack.Reverse();
                else if (choice == 0) flag = true;
                else
                {
                    Console.WriteLine("Введите номер из списка");
                }

            }

            // Дек #####################################################

            Console.WriteLine("Часть 3, Дек");
            flag = false;
            text = @"Выберите действие
            1) Добавить элемент в начало
            2) Добавить элемент в конец
            3) Удалить элемент из начала
            4) Удалить эдемент из конца
            5) Проверить дек на пустоту
            6) Вывести стек
            7) Очистить стек
            8) Выполнить задание
            0) Выйти";

            DeckList deck = new DeckList();


            while (!flag)
            {
                int choice = get_number(text);
                if (choice == 1)
                {
                    int n = get_number("Введите число для добавления в начало");
                    deck.AddNodeFirst(n);
                }
                else if (choice == 2)
                {
                    int n = get_number("Введите число для добавления в конец");
                    deck.AddBack(n);
                }
                else if (choice == 3) deck.RemoveNodeStart();
                else if (choice == 4) deck.RemoveNodeLast();
                else if (choice == 5)
                {
                    bool check_deck = deck.CheckEmpty();
                    if (!check_deck) Console.WriteLine("Дек пуст");
                    else Console.WriteLine("Дек не пуст");
                }
                else if (choice == 6) deck.PrintDeck();
                else if (choice == 7) deck.Clear();
                else if (choice == 8) generateNewDecks(deck);
                else flag = true;

            }



        }
    }
}

