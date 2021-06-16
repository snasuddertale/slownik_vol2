using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slownik_vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tools tool = new Tools();
            Manage fun = new Manage();

            while (true) {
                Console.WriteLine("Witaj! Co chcesz zrobić ze słownikiem?");
                Console.WriteLine("> DODAJ");
                Console.WriteLine("> SZUKAJ");
                Console.WriteLine("> RESET");
                Console.WriteLine("> EXIT");
                Console.WriteLine();
                Console.Write("> ");
                string choice = Console.ReadLine().ToString().ToLower();
                Console.WriteLine();
                if (choice == "szukaj")
                {
                    fun.Search();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choice == "dodaj")
                {
                    fun.AddWord();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choice == "reset")
                {
                    tool.HardReset();
                }
                else if (choice == "exit")
                {
                    Console.WriteLine("No to na razie!");
                    Console.ReadKey();
                    break;
                }
                else {
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
