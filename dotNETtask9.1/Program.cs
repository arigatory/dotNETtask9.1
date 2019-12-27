using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace dotNETtask9._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
           
            AnalyzeFile(fileName);
            Console.ReadLine();
        }

        private static void AnalyzeFile(string fName)
        {
            using (StreamReader sr = File.OpenText(fName))
            {
                string input = sr.ReadLine();
                int counter = 0;
                int goodEmailCounter = 0;
                int goodPhoneCounter = 0;
                while ((input = sr.ReadLine())!= null)
                {
                    counter++;
                    string[] data = input.Split(',');
                    string fio = data[0];
                    string email = data[1].Trim();
                    string phone = data[2].Trim();
                    if (AnalyzeEmail(email))
                    {
                        goodEmailCounter++;
                    }
                    if (AnalyzePhone(phone))
                    {
                        goodPhoneCounter++;
                    }
                    Console.WriteLine(input);
                }

                Console.WriteLine();
                Console.WriteLine($"Общее количество сотрудников: {counter}");
                Console.WriteLine($"Количество правильных email: {goodEmailCounter}");
                Console.WriteLine($"Количетсво правильных телефонов {goodPhoneCounter}");
            }
        }

        private static bool AnalyzePhone(string s)
        {
            const string pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex regex = new Regex(pattern);
            return Regex.IsMatch(s, pattern);
        }

        private static bool AnalyzeEmail(string s)
        {
            const string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(pattern);
            return Regex.IsMatch(s, pattern);
        }

    }
}
