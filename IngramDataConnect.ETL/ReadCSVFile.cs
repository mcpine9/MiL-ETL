using System;
using System.IO;

namespace IngramDataConnect.ETL
{
    public class ReadCSVFile : IReadFile
    {
        public bool IsValidPath { get; set; }
        public bool IsValidFileType { get; set; }
        public bool IsSuccessfullRead { get; set; }
        public string InvalidPathMessage { get; set; }
        public string InvalidFileTypeMessage { get; set; } 
        public string ErrorReadingMessage { get; set; }
        public StreamReader TextReader { get; set; }

        public void ReadFile(string path)
        {
            if (path.EndsWith(".csv") && !String.IsNullOrEmpty(path))
            {
                IsValidFileType = true;
                if (File.Exists(path))
                {
                    IsValidPath = true;
                    try
                    {
                        TextReader = new StreamReader(path);
                        IsSuccessfullRead = true;
                    }
                    catch (Exception e)
                    {
                        IsSuccessfullRead = false;
                        ErrorReadingMessage = "There was an error reading this file: " + e.Message;
                        TextReader.Close();
                    }
                }
                else
                {
                    IsValidPath = false;    
                    InvalidPathMessage = "This is an invalid path.";
                }
            }
            else
            {
                IsValidFileType = false;
                InvalidFileTypeMessage = "The file must be of type \".csv\".";
            }
        }
    }
}
