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
        public static List<string> stopWordList = new List<string>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            PopulateStopWords();

            string filePath = @"Assets\mobydick-chapter-text.txt";
            StreamReader file =
                new System.IO.StreamReader(filePath);

            ParseBook(file);

            CountDistinct();

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
            //Console.WriteLine("There were {0} lines.", counter);
            //Console.WriteLine("There are {0} words in the book.", Globals.wordList.Count);
            // Suspend the screen.  
            //Console.ReadLine();
        }

        public static void PopulateStopWords()
        {
            int counter = 0;
            string line;

            string filePath = @"Assets\stop-words.txt";
            StreamReader file =
                new System.IO.StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                if (line != string.Empty && line.IndexOf("#") == -1)
                {
                    //Console.WriteLine(line);
                    Globals.stopWordList.Add(line.ToLower());
                    counter++;
                }                
            }

            file.Close();
            //Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            //Console.ReadLine();
        }

        public static void ParseLine(string line)
        {
            char[] delimiterChars = { ' ', ',', '.', '?', '!', ';',  ':', '\'', '“', '”', '(', ')', '\"', '*', '‘', '’', '[', ']', '\t', (char)0x2014 };

            // Console.WriteLine($"Line text: '{line}'");

            string[] words = line.Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                if (!Globals.stopWordList.Contains(word.ToLower()))
                {
                    Globals.wordList.Add(word.ToLower());
                    //Console.WriteLine($"{word}");
                }
            }

            //Console.ReadLine();
        }

        public static void CountDistinct()
        {
            var topWords = Globals.wordList.GroupBy(s => s).OrderByDescending(g => g.Count()).Take(100);
            int i = 1;
            foreach (var grp in topWords)
            {
                Console.WriteLine("{0}: {1} ({2})", i, grp.Key, grp.Count());
                i++;
            }

            Console.ReadLine();
        }
    }
}
