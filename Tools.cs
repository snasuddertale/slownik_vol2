using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slownik_vol2
{
    class Tools
    {

        public void ReadList(List<string> list) {
            foreach (var dot in list)
            {
                string res = dot.Remove(dot.Length - 4, 4).Remove(0, 13);
                Console.WriteLine(res);
            }
        }
        public void OtherReadList(List<string> list)
        {
            foreach (var dot in list)
            {
                Console.WriteLine(dot);
            }
        }

        public string SomeChs(string name, int n) {

            string letter = name.Substring(0, n);

            return letter;
        }

        public string OneChs(string name, int n)
        {           
            string letter = name.Substring(n, 1);

            return letter;
        }
        public void HardReset() {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Jesteś pewien, że chcesz wykasować zawartość słownika? (Y/N)");
                Console.Write("> ");
                string ch1 = Console.ReadLine().ToString().ToLower();
                if (ch1 == "n")
                {
                    Console.Clear();
                    break;
                }
                else if (ch1 == "y")
                {
                    Console.WriteLine("Ale jesteś pewien tak na 100%?");
                    Console.Write("> ");
                    string ch2 = Console.ReadLine().ToString().ToLower();
                    if (ch2 == "n")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (ch1 == "y")
                    {
                        string path = @"..\..\spis\";
                        System.IO.DirectoryInfo di = new DirectoryInfo(path);

                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                        Encoding ascii = Encoding.ASCII;
                        int i = 97;
                        if (i > 96 && i < 123)
                        {
                            if (i != 113 && i != 118 && i != 120 && i != 121)
                            {
                                var text = char.ConvertFromUtf32(i);
                                string where = path + text.ToString();
                                Directory.CreateDirectory(where);
                                i++;
                            }
                        }
                        Console.WriteLine("Zawartość słownika została zresetowana!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else 
                {
                    Console.Clear();
                    continue;
                }
            }

        }

        public List<string> MakeAList(string path)
        {
            List<string> list = new List<string>();

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                list.Add(file);
            }
            return list;
        }

        public string PathMaker(string name) {
            return @"..\..\spis\" + OneChs(name, 0) + "/" + name + ".txt";
        }
        public string LilPathMaker(string name)
        {
            return @"..\..\spis\" + OneChs(name, 0);
        }

        public void Definition(string word) {

            string path = PathMaker(word);

            try
            {
                using (var outputFile = new StreamReader(path))
                {
                    Console.WriteLine(outputFile.ReadToEnd());
                    outputFile.Close();
                }
            }
            catch (IOException fileUnreadable)
            {
                Console.WriteLine(fileUnreadable.Message);
            }
        }

        public List<string> OtherList(string word) {

            List<string> list = MakeAList(LilPathMaker(word));
            List<string> final = new List<string>();

            foreach (var dot in list)
            {
                string res = dot.Remove(dot.Length - 4, 4).Remove(0, 13);
                if (word == (SomeChs(res, word.Length))) {
                    final.Add(res);
                }
            }
            return final;
        }

        public void GetDef() {
            Console.WriteLine("Jakiego słowa definicji potrzebujesz?");
            Console.WriteLine("> ");
            string word = Console.ReadLine();
            string path = PathMaker(word);

            if (!System.IO.File.Exists(path))
            {
                try
                {
                    using (var outputFile = new StreamReader(path))
                    {
                        Console.WriteLine(outputFile.ReadToEnd());
                        outputFile.Close();
                    }
                }
                catch (IOException fileUnreadable)
                {
                    Console.WriteLine(fileUnreadable.Message);
                }
            }
            else
            {
                while (true) {
                Console.WriteLine("Taki plik nie istnieje! Ale... Może chcesz to zmienić? (Y/N)");
                Console.Write("> ");
                string choice = Console.ReadLine().ToString().ToLower();
                    if (choice == "y")
                    {
                        Manage wow = new Manage();
                        Console.ReadKey();
                        Console.Clear();
                        wow.AddWord();
                    }
                    else if (choice == "n")
                    {
                        break;
                    }
                    else 
                    {
                        continue;
                    }
            }
            }
        }

        public bool DoesItExist(string word) {
            return (File.Exists(PathMaker(word)));
        }

        public void WordAdder(string name, string def) {

            string path = PathMaker(name);
            if (!Directory.Exists(LilPathMaker(name)))
            {
                Directory.CreateDirectory(LilPathMaker(name));
            }
            if (!System.IO.File.Exists(LilPathMaker(name)))
            {
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(path))
                    {
                        outputFile.WriteLine(def);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else {
                try {
                    using (StreamWriter outputFile = File.AppendText(path))
                    {
                        outputFile.WriteLine(def);
                    }
                }

                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
