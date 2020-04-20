using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyDickProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Assets\mobydick-chapter-text.txt";
            StreamReader file =
                new System.IO.StreamReader(filePath);

            ParseBook(file);                        
        }

        public static void ParseBook(StreamReader file)
        {
            int counter = 0;
            string line;
                        
            while ((line = file.ReadLine()) != null)
            {
                // ignore CHAPTER header lines
                if (line.Length > 0 && line.ToUpper().Substring(0, 7) != "CHAPTER")
                {
                    // parse each line and do stuff
                    ParseLine(line);

                    System.Console.WriteLine(line);
                    counter++;
                }
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }

        public static List<string> GetStopWords()
        {
            List<string> stopWordList = new List<string>();
            int counter = 0;
            string line;

            string filePath = @"Assets\stop-words.txt";
            StreamReader file =
                new System.IO.StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                if (line != string.Empty && line.IndexOf("#") == -1)
                {
                    System.Console.WriteLine(line);
                    stopWordList.Add(line);
                    counter++;
                }                
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();

            return stopWordList;
        }

        public static void ParseLine(string line)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', (char)0x2014 };

            System.Console.WriteLine($"Line text: '{line}'");

            string[] words = line.Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                System.Console.WriteLine($"{word}");
            }

            Console.ReadLine();
        }
    }
}
