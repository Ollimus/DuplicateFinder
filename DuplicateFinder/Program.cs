using System;
using System.Collections.Generic;
using System.IO;

namespace DuplicateFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            String readPath = @"Input.txt";
            String writePath = @"Output.txt";

            List<string> list = new List<string>();

            using (StreamReader sr = File.OpenText(readPath))
            {
                String s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(s))
                        continue;

                    if (!list.Contains(s))
                        list.Add(s);
                }
            }

            File.WriteAllText(writePath, string.Empty);

            using (StreamWriter sr = File.AppendText(writePath))
            {
                foreach (var entry in list)
                {
                    sr.WriteLine(entry);
                }

                sr.Close();
            }

            Console.WriteLine("Completed succesfully. Press any key to end.");
            Console.ReadKey();
        }
    }
}
