using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static string fileName = "C:/test.txt";
     
            public static void Main(string[] args)
            {
               
                //Check for/create test.txt
                createTestFile(fileName);   
            }

        public static void createTestFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file 
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes("Test Txt File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("James Warner");
                    fs.Write(author, 0, author.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static string method(string arg1, string arg2)
        {
            FileDetails fileDetails = new FileDetails();
            string returnValue = "";
           
            //Check arg1
            if (arg1 == "-v" || arg1 == "--v" || arg1 == "/ v" || arg1 == "/v")
            {
              returnValue = fileDetails.Version(fileName);
            }
            else if (arg1 == "-s" || arg1 == "--s" || arg1 == "/ s" || arg1 == "/s")
            {
                returnValue = fileDetails.Size(fileName).ToString();
            }
            else
            {
                //Do nothing
            }

            Console.WriteLine(returnValue);
            return returnValue;
 
        }
    }





}
 