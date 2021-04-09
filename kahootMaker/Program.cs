using System;
using System.Collections.Generic;
using System.IO;
namespace kahootMaker
{
    class Program
    {
        public const String inputFile = @"your input file here"; //YOU MUST INCLUDE FILE EXTENSION; IT CAN ONLY READ .txt files
        public const String outputFile = @"your output file here";
        public static List<string> trimList(List<string> inLines)
        {
            string[] lines = inLines.ToArray();
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
        public static List<string> filterBrackets(string[] input )
        {
            List<string> filteredOutput = new List<string>();

            foreach (var item in input)
            {
                filteredOutput.Add(item);
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!filteredOutput[i].Contains("["))
                {
                    if (!filteredOutput[i].Contains(""))
                    {
                        filteredOutput.RemoveAt(i);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            return filteredOutput;
        }
        public static string dealWithCommas(String input)
        {
            
            const string quote = "\"\"";
            string[] splitInput = input.Split(',');
            string output ="";
            for (int i = 0; i <( splitInput.Length -1); i++)
            {
                output += splitInput[i] + quote + ","  + quote;
            }
            output += splitInput[(splitInput.Length - 1)];
            return (output);
        }
        public static void makeCSV(List<string> itemsToInsert)
        {
            StreamWriter file = new StreamWriter(outputFile, append: false);
          
            int k = 0;
            string[] qAndA = itemsToInsert.ToArray();
            for (int i = 1; i < 101; i++)
            {
                String[] output = new String[8];
                output[0] = i.ToString();
                bool validAnswer = true;
                while (validAnswer && k < (qAndA.Length - 3))
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
                    if (output[ik] == null)
                    {
                        output[ik] = "NEED ANSWER";
                    }
                }
                if (output[0] == "NEED ANSWER")
                {
                    for (int ik = 0; ik < output.Length; ik++)
                    {
                        output[ik] = "";
                    }
                }
                string itemToWrite = "";
                foreach (var item in output)
                {
                    itemToWrite += item + "|";
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
            
            List<string> ls = new List<string>();
            string[] lines = System.IO.File.ReadAllLines((inputFile));
            ls = filterBrackets(lines); //This doesn't work
            ls = trimList(ls);
            makeCSV(ls);
           
        }
    }
}
