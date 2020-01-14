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
            string fileName = "input.csv";
            if (args.Length == 1)
                fileName = args[0];
           
            AnalyzeFile(fileName);
            Console.ReadLine();
        }

        private static void AnalyzeFile(string fName)
        {
            using (StreamReader sr = new StreamReader(fName, Encoding.GetEncoding(1251)))
            {
                string input = sr.ReadLine();
                int numberOfPeople = 0;
                List<string> badPhones = new List<string>();
                List<string> badEmails = new List<string>();
                while ((input = sr.ReadLine()) != null)
                {
                    
                    numberOfPeople++;
                    string[] data = input.Split('\t');
                    string fio = data[0].Trim('"');
                    string email = data[1].Trim('"');
                    string phone = data[2].Trim('"');
                    if (!AnalyzeEmail(email))
                    {
                        badEmails.Add(email);
                    }
                    if (!AnalyzePhone(phone))
                    {
                        badPhones.Add(phone);
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Общее количество сотрудников: {numberOfPeople}");
                Console.WriteLine($"Количество правильных email: {numberOfPeople - badEmails.Count}");
                Console.WriteLine($"Количетсво правильных телефонов {numberOfPeople - badPhones.Count}");

                Console.WriteLine("\nНеправильные номера:");
                foreach(string item in badPhones)
                {
                    Console.WriteLine($"\t{item}");
                }

                Console.WriteLine("\nНеправильные email:");
                foreach (string item in badEmails)
                {
                    Console.WriteLine($"\t{item}");
                }
            }
        }

        private static bool AnalyzePhone(string s)
        {
            const string pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
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
