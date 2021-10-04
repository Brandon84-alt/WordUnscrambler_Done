using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            //string path = @"scrambleWords.txt";

            string[] readText = File.ReadAllLines(filename);

            //Console.WriteLine(readText);


            return readText;

        }
    }
}

