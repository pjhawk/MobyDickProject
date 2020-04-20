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
            ParseBook(filePath);

            ShowTopWords(100);
        }

        public static void ParseBook(string filePath)
        {
            int counter = 0;
            string line;

            StreamReader file =
                new System.IO.StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                // ignore CHAPTER header lines
                if (line.Length > 6 && line.ToUpper().Substring(0, 7) != "CHAPTER")
                {
                    ParseLine(line);
                    counter++;
                }
            }

            file.Close();            
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
                // stop words file has some comments at the top that start with a #
                // and includes a blank line between each word
                // ignore these lines
                if (line != string.Empty && line.Substring(0,1) != "#")
                {
                    Globals.stopWordList.Add(line.ToLower());
                    counter++;
                }                
            }

            file.Close();
        }

        public static void ParseLine(string line)
        {
            // create an array of common char delmiters
            char emDash = (char)0x2014;
            char[] delimiterChars = { ' ', ',', '.', '?', '!', ';',  ':', '\'', '“', '”', '(', ')', '\"', '*', '‘', '’', '[', ']', '\t', emDash };

            // parse line into an array of words
            string[] words = line.Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);            

            foreach (var word in words)
            {
                // check if word exists in stop word list
                // if not add it to the word list
                if (!Globals.stopWordList.Contains(word.ToLower()))
                {
                    Globals.wordList.Add(word.ToLower());                    
                }
            }
        }

        public static void ShowTopWords(int limit)
        {
            // group word list by distict words and sort by count is desc order
            // then select the number of groups passed to the function
            var topWords = Globals.wordList.GroupBy(s => s).OrderByDescending(g => g.Count()).Take(limit);
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
