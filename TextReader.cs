using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project2
{
    internal class TextReader
    {
        string inputLine = "";



        private int Counter(string input)
        {
            int count = 0;
         
            char[] arrChar = input.ToCharArray();

            for (int i = 0; i < arrChar.Length; i++)
            {
                if (arrChar[i] == 'a')
                {
                    count++;
                }
            }

            return count;
        }

        private string ReadUserInput()
        {
            inputLine = Console.ReadLine();

            return inputLine;
        }

        private int OpenText(string filepath)
        {
            bool flag = false;
            string read = "";
            if(File.Exists(filepath))
            {
                flag = true;
            }

            if(flag==true)
            {
                
              
                read = File.ReadAllText(filepath);
                
            }

          return Counter(read);
        }

        private bool PathIsValid(string filePath)
        {
            bool result;
            Regex rg = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");

            if (rg.IsMatch(filePath))
            {
              
                result = true;
            }
            else
            {
                result = false;
            }
              
            return result;

        }

        public void Process()
        {
            string input = ReadUserInput();
            if(PathIsValid(input))
            {
                Console.WriteLine("Input is a file path..");
                Console.WriteLine(OpenText(input));
            } 
            else
            {
                Console.WriteLine("Input is not a file path ..");
                Console.WriteLine(Counter(input));
            }

        }


       
    }
}
