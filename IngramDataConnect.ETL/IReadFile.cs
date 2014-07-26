using System.IO;

namespace IngramDataConnect.ETL
{
    public interface IReadFile
    {
        bool IsValidPath { get; set; }
        bool IsValidFileType { get; set; }
        bool IsSuccessfullRead { get; set; }
        string InvalidPathMessage { get; set; }
        string InvalidFileTypeMessage { get; set; }
        string ErrorReadingMessage { get; set; }
        StreamReader TextReader { get; set; }
        void ReadFile(string path);
    }
}