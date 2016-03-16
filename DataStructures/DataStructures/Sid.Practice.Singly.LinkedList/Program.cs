using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.Singly.LinkedList
{
    class Program
    {
        static LinkedList linkedList = new LinkedList();
        static string key = "n";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter following commands:\nf : Add to front into LinkedList\ne : Add to end into LinkedList\nm : Add to middle to LinkedList\nr : Remove from LinkedList\ns : Peep from LinkedList\nd : Display LinkedList\na : Sort Ascending.\no : Sort descending\nb : Reverse linked list\n");
                Console.Write("Enter Command: ");
                key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();
                Console.WriteLine();
                while (key != "x")
                {
                    try
                    {

                        switch (key)
                        {
                            case "f": AddToLinkedList(key); break;
                            case "e": AddToLinkedList(key); break;
                            case "m": AddToLinkedList(key); break;
                            case "s": PeepFromLinkedList(); break;
                            case "d": Display(); break;
                            case "r": RemoveFromLinkedList(); break;
                            case "a": SortLinkedList(key); break;
                            case "o": SortLinkedList(key); break;
                            case "b": Reverse(); break;
                            default:
                                Console.WriteLine();
                                Console.WriteLine("Invalid Command!!!!");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("***********************");
                                Console.WriteLine("Enter following commands:\nf : Add to front into LinkedList\ne : Add to end into LinkedList\nm : Add to middle to LinkedList\nr : Remove from LinkedList\ns : Peep from LinkedList\nd : Display LinkedList\na : Sort Ascending.\no : Sort descending\n");
                                break;
                        }
                    }
                    catch (MyException exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.WriteLine();
                        Console.WriteLine("***********************");
                        Console.WriteLine("Enter following commands:\nf : Add to front into LinkedList\ne : Add to end into LinkedList\nm : Add to middle to LinkedList\nr : Remove from LinkedList\ns : Peep from LinkedList\nd : Display LinkedList\na : Sort Ascending.\no : Sort descending\n");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Enter Command: ");
                    key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
            }
        }

        private static void AddToLinkedList(string key)
        {
            Console.Write("\nEnter the value:");
            var inputKey = Console.ReadLine().ToLowerInvariant();
            var inputInt = 0;
            Int32.TryParse(key, out inputInt);

            if (inputInt == 0)
            {
                try
                {
                    inputInt = Convert.ToInt32(inputKey);
                }
                catch (Exception)
                {
                    throw new MyException("\nInput valid integer.");
                }
            }
            switch (key)
            {
                case "f": linkedList.AddNodeAtFront(inputInt); break;
                case "e": linkedList.AddNodeAtRear(inputInt); break;
                case "m": linkedList.AddNodeInMiddle(inputInt); break;
                default:
                    break;
            }
        }

        private static void Display()
        {
            Console.WriteLine("\n");
            linkedList.Display();
        }

        private static void Reverse()
        {
            Console.WriteLine("\n");
            linkedList.Reverse();
            linkedList.Display();
        }

        private static void RemoveFromLinkedList()
        {
            Console.Write("\nEnter the value:");
            var key = Console.ReadLine().ToLowerInvariant();
            var inputInt = 0;
            Int32.TryParse(key, out inputInt);

            if (inputInt == 0)
            {
                try
                {
                    inputInt = Convert.ToInt32(key);
                }
                catch (Exception)
                {
                    throw new MyException("\nInput valid integer.");
                }
            }

            SinglyNode RemovepedNode = linkedList.RemoveNode(inputInt);
            RemovepedNode.Display();
        }

        private static void PeepFromLinkedList()
        {
            SinglyNode RemovepedNode = null;
            Console.Write("\nEnter the position:");
            var key = Console.ReadLine().ToLowerInvariant();
            var inputInt = 0;
            Int32.TryParse(key, out inputInt);
            if (inputInt > 0)
            {
                RemovepedNode = linkedList.Peep(inputInt);
            }
            else
            {
                RemovepedNode = linkedList.Peep(0);
            }

            RemovepedNode.Display();
        }

        /// <summary>
        /// The sort linked list.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        private static void SortLinkedList(string key)
        {
            switch (key)
            {
                case "a":
                    linkedList.SortListAscending();
                    break;
                case "o":
                    linkedList.SortListDescending();
                    break;
                default: break;
            }
        }
    }
}

