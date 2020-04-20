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

            ShowBookTextLines(file);            
        }

        public static void ShowBookTextLines(StreamReader file)
        {
            int counter = 0;
            string line;
            
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
