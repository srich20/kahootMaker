using System;
using System.Collections.Generic;
using System.IO;
namespace kahootMaker
{
    class Program
    {
        public static List<string> trimList(string[] lines)
        {
            List<string> trim1 = new List<string>();
            List<string> finalTrim = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                trim1.AddRange(lines[i].Split('['));
            }
            foreach (string item in trim1)
            {
                String i = item.Trim();
                
                finalTrim.Add(i.Trim(']'));
            }
            return finalTrim;
        }
        public static void makeCSV(List<string> itemsToInsert)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\mrset\Desktop\TestOut.txt", append: true);
            int k = 0;
            string[] qAndA = itemsToInsert.ToArray();
            for (int i = 1; i < 101; i++)
            {
                String[] output = new String[8];
                output[0] = i.ToString();
                bool validAnswer = true;
                while (validAnswer && k < 264)
                {
                    if(qAndA[k] == "")
                    {
                        k++;
                    }
                    else
                    {
                        validAnswer = false;
                        if (k < (qAndA.Length - 1))
                        {

                            output[1] = qAndA[k];
                            k++;
                            Random r = new Random();
                            int indexOfAnswer = (r.Next(4) + 2);
                            if (indexOfAnswer < 5)
                            {
                                if (true)
                                {

                                }
                            }
                            else
                            {

                            }
                            output[indexOfAnswer] = qAndA[k];
                            k++;
                            output[7] = (indexOfAnswer - 1).ToString();
                            if (isValidLength(output[1]))
                            {
                                output[6] = "30";
                            }
                            else
                            {
                                output[1] = "NEED SCREENSHOT";
                                output[6] = "75";
                            }
                        }
                    }
                }
                for (int ik = 0; ik < output.Length; ik++)
                {
                    if (output[ik] == "")
                    {
                        output[ik] = "NEED ANSWER";
                    }
                }
                string itemToWrite = "";
                foreach (var item in output)
                {
                    itemToWrite += item + ",";
                }
                itemToWrite += "";
                file.WriteLine(itemToWrite);
            }
            file.Flush();
            file.Close();
           
        }
        public static bool isValidLength(string str)
        {
            int count = 0;
            char[] charStr = str.ToCharArray();
            foreach (var item in charStr)
            {
                count++;
            }
            if (count > 120)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            StreamReader reader = new StreamReader(@"C:\Users\mrset\Desktop\test.txt");
            List<string> ls = new List<string>();
            string[] lines = System.IO.File.ReadAllLines((@"C:\Users\mrset\Desktop\test.txt"));
            ls = trimList(lines);
            Console.WriteLine(ls);
            makeCSV(ls);
           
        }
    }
}
