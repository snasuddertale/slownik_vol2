using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slownik_vol2
{
    class Manage
    {
        public void Search()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Szukajka: ");
                Console.Write("> ");
                string choice = Console.ReadLine().ToString().ToLower();
                string backup = choice;
                if (choice == "help")
                {
                    Console.WriteLine("Aby wyjść, wpisz EXIT. Aby szukać, wpisz cokolwiek innego.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else if (choice == "exit")
                {
                    Console.Clear();
                    break;
                }
                else if (choice.Length == 0)
                {
                    continue;
                }
                else
                {
                    Tools tool = new Tools();
                    string path = tool.LilPathMaker(tool.OneChs(choice, 0));
                    if (tool.OtherList(choice).Count != 0)
                    {
                        while (true)
                        {
                            if (System.IO.Directory.Exists(path))
                            {
                                if (choice.Length > 0)
                                {
                                    tool.OtherReadList(tool.OtherList(choice));
                                    Console.ReadKey();
                                    Console.WriteLine("\nWybierz słowo, którego definicję chcesz sprawdzić lub dodać.");
                                    Console.Write("> ");
                                    string word = Console.ReadLine().ToString().ToLower();
                                    Console.ReadKey();
                                    Console.Clear();

                                    if (tool.DoesItExist(word))
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("Chcesz je (S)sprawdzić, czy (D)dodać?");
                                            Console.Write("> ");
                                            string soz = Console.ReadLine().ToString().ToLower();
                                            Console.ReadKey();
                                            Console.Clear();

                                            if (soz == "s")
                                            {
                                                tool.Definition(word);
                                                Console.ReadKey();
                                                break;
                                            }
                                            else if (soz == "d")
                                            {
                                                while (true)
                                                {
                                                    Console.WriteLine("Napisz definicję, którą chciałbyś dodać");
                                                    Console.Write("> ");
                                                    string def = Console.ReadLine().ToString().ToLower();
                                                    Console.WriteLine("Czy pasuje ci ta definicja?(Y/N)");
                                                    Console.Write("> ");
                                                    string choi = Console.ReadLine().ToString().ToLower();
                                                    if (choi == "y")
                                                    {
                                                        tool.WordAdder(word, def);
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ojojojoojojoj");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                }
                                                break;
                                            }
                                            break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("b a z i n g a");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wygląda na to, że lista jest pusta!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Wygląda na to, że lista jest pusta!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
                break;
            }
        }

        public void AddingWord(string word) {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chcesz dodać definicję słowa " + word + "?(Y/N)");
                Console.Write("> ");
                string choice = Console.ReadLine().ToString().ToLower();
                if (choice == "n")
                {
                    break;
                }
                else if (choice == "y")
                {
                    while (true) {                       
                        Console.Clear();
                        Console.WriteLine("Jak byś określił " + word + "?");
                        Console.Write("> ");
                        string def = Console.ReadLine().ToString();

                        Console.Clear();
                        Console.WriteLine("Czy jesteś pewien (Y/N), że chcesz zdefiniować " + word + " jako \n" + def + "\n");
                        if (choice == "y")
                        {
                            Tools tool = new Tools();
                            tool.WordAdder(word, def);
                            break;
                        }
                        else if (choice == "n")
                        {
                            Console.WriteLine("Zrozumiałe, spróbujmy jeszcze raz!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (choice == "exit"){
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nie mam pojęcia co masz na myśli, więc spróbujmy jeszcze raz!");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nie rozumiem..?");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                break;
            }
        }

        public void AddWord() {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chcesz dodać nowe słowo do słownika? (Y/N)");
                string choice = Console.ReadLine().ToLower().ToString();
                if (choice == "y")
                {
                    while (true) {                      
                        Console.WriteLine("Podaj słowo:");
                        Console.Write("> ");

                        string word = Console.ReadLine().ToString().ToLower();

                        Console.WriteLine("Podaj definicje słowa:");
                        Console.Write("> ");

                        string def = Console.ReadLine().ToString();

                        Console.Clear();
                        Console.WriteLine("Czy jesteś pewien (Y/N), że chcesz zdefiniować " + word + " jako \n" + def + "\n");
                        if (choice == "y") {
                            Tools tool = new Tools();
                            tool.WordAdder(word, def);
                            break;
                        }
                        else {
                            Console.WriteLine("Zrozumiałe (lub nie), miłego dnia");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                    break;
                }
                else if (choice == "n")
                {
                    Console.WriteLine("Zrozumiałe, miłego dnia");
                    break;
                }
                else {
                    Console.WriteLine("Nie rozumiem");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

            }
        }
    }
}
