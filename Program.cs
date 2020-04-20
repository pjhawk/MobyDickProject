using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyDickProject
{
    static class Globals
    {
        public static List<string> wordList = new List<string>();
        public static List<string> distictWordList = new List<string>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Assets\mobydick-chapter-text.txt";
            StreamReader file =
                new System.IO.StreamReader(filePath);

            ParseBook(file);

            GetDistinctList(Globals.wordList);
        }

        public static void ParseBook(StreamReader file)
        {
            int counter = 0;
            string line;            
                        
            while ((line = file.ReadLine()) != null)
            {
                // ignore CHAPTER header lines
                if (line.Length > 6 && line.ToUpper().Substring(0, 7) != "CHAPTER")
                {
                    // parse each line and do stuff
                    ParseLine(line);

                    //Console.WriteLine(line);
                    counter++;
                }
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.WriteLine("There are {0} words in the book.", Globals.wordList.Count);
            Console.ReadLine();
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
                    Console.WriteLine(line);
                    stopWordList.Add(line);
                    counter++;
                }                
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();

            return stopWordList;
        }

        public static void ParseLine(string line)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', (char)0x2014 };

            // Console.WriteLine($"Line text: '{line}'");

            string[] words = line.Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                Globals.wordList.Add(word);
                //Console.WriteLine($"{word}");
            }

            //Console.ReadLine();
        }

        public static void GetDistinctList(List<string> list)
        {
            IEnumerable<string> distinctWords = list.Distinct();

            foreach (string word in distinctWords)
            {
                Globals.distictWordList.Add(word);
            }
        }
    }
}
