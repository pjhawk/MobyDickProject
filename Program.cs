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

            //ShowBookTextLines(file);            
            GetStopWords();
        }

        public static void ShowBookTextLines(StreamReader file)
        {
            int counter = 0;
            string line;
            
            while ((line = file.ReadLine()) != null)
            {
                // parse each line and do stuff
                // ignore CHAPTER header lines
                // 
                System.Console.WriteLine(line);
                counter++;
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
    }
}
